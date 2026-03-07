using AutoMapper;
using DailyAPP.WebAPI.ApiReponses;
using DailyAPP.WebAPI.DataModel;
using DailyAPP.WebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyAPP.WebAPI.Controllers
{
    /// <summary>
    /// 账号接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DailyDbContext db;

        private readonly IMapper mapper;

        public AccountController(DailyDbContext _db,IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        /// <summary>
        /// 账号注册
        /// </summary>
        /// <param name="accountInfoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegiestAccount(AccountInfoDTO accountInfoDTO)
        {
            ApiResponse res = new ApiResponse();

            try
            {
                var dbAccount = db.AccountInfo.Where(x => x.Account == accountInfoDTO.Account).FirstOrDefault();
                if(dbAccount != null)
                {
                    res.ResultCode = -1;//账号已存在
                    res.msg = "账号已存在";
                    return Ok(res);
                }
                //AccountInfo accountInfo = new AccountInfo()
                //{
                //    Account = accountInfoDTO.Account,
                //    Name = accountInfoDTO.Name,
                //    Pwd = accountInfoDTO.Pwd
                //};
                AccountInfo accountInfo = mapper.Map<AccountInfo>(accountInfoDTO);

                db.AccountInfo.Add(accountInfo);
                int row = db.SaveChanges();//保存
                if(row > 0)
                {
                    res.ResultCode = 200;
                    res.msg = "注册成功";
                }
                else
                {
                    res.ResultCode = -99;
                    res.msg = "服务器忙，请稍等";
                }
            }
            catch (Exception)
            {
                res.ResultCode = -919;
                res.msg = "服务器忙，请稍等";
            }

            return Ok(res);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            ApiResponse res = new ApiResponse();
            var dbAccount = db.AccountInfo.Where(x=>x.Account == username).FirstOrDefault();
            if(dbAccount == null)
            {
                res.ResultCode = -1;
                res.msg = "账号不存在";
                return Ok(res);
            }
            if(!string.Equals(dbAccount.Pwd,password))
            {
                res.ResultCode = -1;
                res.msg = "密码错误";
                return Ok(res);
            }
            res.ResultCode = 200;
            res.msg = "登录成功";
            res.ResultData = new AccountInfo()
            {
                Account = dbAccount.Account,
                AccountId = dbAccount.AccountId,
                Name = dbAccount.Name
            };
            return Ok(res);
        }
    }
}
