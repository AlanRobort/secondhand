﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using WebApi.Interface;
using WebApi.ResourceParameter;
using WebApi.Viewmodel;

namespace WebApi.Services
{
    public class CustomersService : ICustomersInterface
    {
        private readonly ProductDbContext _dbContext;

        public CustomersService(
            ProductDbContext dbContext 
           )
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 添加顾客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddCustomerasync(Customer model)
        {
            if (model != null)
            {
                await _dbContext.Customerlists.AddAsync(model);
                var result = await _dbContext.SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// 删除顾客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCustomersasync(int id)
        {
          
              var result = await GetCustomerasync(id);
                _dbContext.Customerlists.Remove(result);
              var num =  await _dbContext.SaveChangesAsync();
             if (num > 0)
             {
                 return true;
             }

             return false;
        }

        /// <summary>
        /// 获取单个顾客信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async  Task<Customer> GetCustomerasync(int id)
        {
           
               var result = await _dbContext.Customerlists.FirstOrDefaultAsync(x=>x.Id==id);

               return result;
        }

        /// <summary>
        /// 获取所有顾客信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetCustomersasync(CoustomerParameter coustomerParameter)
        {
            var result = new List<Customer>();
            var query = new List<Customer>() as IQueryable<Customer>;
            if (string.IsNullOrWhiteSpace(coustomerParameter.SearchItem))
            {
                
                //var result = await _dbContext.Customers.ToListAsync();
                 query = from Customer in _dbContext.Customerlists
                    select new Customer
                    {
                        Id = Customer.Id,
                        CustomerName = Customer.CustomerName,
                        Username = Customer.Username,
                        Password = Customer.Password,
                        Gender = Customer.Gender,
                        Idcard = Customer.Idcard,
                        Age = Customer.Age,
                        Email = Customer.Email,
                        Phone = Customer.Phone,
                        Address = Customer.Address
                    };
                 result = await query.ToListAsync();
                return result.Skip(coustomerParameter.PageSize * (coustomerParameter.PageNumber - 1))
                    .Take(coustomerParameter.PageSize);
            }

            //查询（可以通过，名字，手机号，用户名，身份证）
            query = from Customer in _dbContext.Customerlists
                where (Customer.CustomerName.Contains(coustomerParameter.SearchItem)||
                       Customer.Username.Contains(coustomerParameter.SearchItem)||
                       Customer.Phone.Contains(coustomerParameter.SearchItem)||
                       Customer.Idcard.Contains(coustomerParameter.SearchItem))
                select new Customer
                {
                    Id = Customer.Id,
                    CustomerName = Customer.CustomerName,
                    Username = Customer.Username,
                    Password = Customer.Password,
                    Gender = Customer.Gender,
                    Idcard = Customer.Idcard,
                    Age = Customer.Age,
                    Email = Customer.Email,
                    Phone = Customer.Phone,
                    Address = Customer.Address
                };

            result = await query.ToListAsync();

            return result.Skip(coustomerParameter.PageSize * (coustomerParameter.PageNumber - 1))
                .Take(coustomerParameter.PageSize);

        }

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCustomersasync(Customer model)
        {
            var result = await GetCustomerasync(model.Id);

            if (result != null)
            {

                //_dbContext.Customerlists.Update(model);
                result.CustomerName = model.CustomerName;
                result.Username = model.Username;
                result.Password = model.Password;
                result.Gender = model.Gender;
                result.Idcard = model.Idcard;
                result.Age = model.Age;
                result.Email = model.Email;
                result.Phone = model.Phone;
                result.Address = model.Address;
                var num = await _dbContext.SaveChangesAsync();
                if (num > 0)
                {
                    return true;
                }
               
                    return false;
            }
            return false;
        }

        /// <summary>
        /// 客户登陆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> CustomerLoginasync(CustomerLoginmodel model)
        {
            if (model != null)
            {
                var result = await _dbContext.Customerlists.FirstOrDefaultAsync(x =>
                    x.Username == model.Customername
                    && x.Password == model.Customerpassword);
                if (result != null)
                {
                    return true;
                }
            }
            return false;

        }


        public async Task<bool> CustomerRegistered(RegisteredUserViewmodel model)
        {
            var result = true;
            var getcustomer = await _dbContext.Customerlists.FirstOrDefaultAsync(x => x.Username == model.Username);
            if (getcustomer != null)
            {
                result = false;
            }
            else
            {
                Customer cs = new Customer();
                cs.Username = model.Username;
                cs.Password = model.Password;
                cs.Email = model.Email;
                await AddCustomerasync(cs);
                await _dbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}
