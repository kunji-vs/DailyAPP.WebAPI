using AutoMapper;
using DailyAPP.WebAPI.ApiReponses;
using DailyAPP.WebAPI.DataModel;
using DailyAPP.WebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyAPP.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DailyDbContext db;

        private readonly IMapper mapper;

        public DataController(DailyDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenuData()
        {

            var dbContent = db.MenuInfos.ToList();
            var menuList = mapper.Map<List<MenuInfoDTO>>(dbContent);
            ApiResponse res = new ApiResponse()
            {
                ResultCode = 200,
                msg = "获取成功",
                ResultData = menuList,
            };
            return Ok(res);
        }

        /// <summary>
        /// 获取待办事项数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWaitData(int accountId)
        {
            var dbContent = db.WaitInfos.Where(x=>x.AccountId == accountId).ToList();
            var waitList = mapper.Map<List<WaitInfoDTO>>(dbContent);
            ApiResponse res = new ApiResponse()
            {
                ResultCode = 200,
                msg = "获取成功",
                ResultData = waitList,
            };
            return Ok(res);
        }
        /// <summary>
        /// 添加待办数据
        /// </summary>
        /// <param name="waitInfoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddWaitData(WaitInfoDTO waitInfoDTO)
        {
            var res = new ApiResponse();
            try
            {
                var waitInfo = mapper.Map<WaitInfo>(waitInfoDTO);
                var add = db.Add(waitInfo);
                int row = db.SaveChanges();
                if (row >= 0)
                {
                    res.msg = "添加成功";
                    res.ResultCode = 200;
                }
                else
                {
                    res.msg = "添加失败";
                    res.ResultCode = -1;
                }
            }
            catch (Exception)
            {
                res.msg = "服务器正忙。。。";
                res.ResultCode = -1;
            }
            return Ok(res);
        }

        /// <summary>
        /// 更新待办
        /// </summary>
        /// <param name="waitInfoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateWaitData(WaitInfoDTO waitInfoDTO)
        {
            var res = new ApiResponse();
            try
            {
                var waitInfo = mapper.Map<WaitInfo>(waitInfoDTO);
                var update = db.Update(waitInfo);
                int row = db.SaveChanges();
                if (row >= 0)
                {
                    res.msg = "更新成功";
                    res.ResultCode = 200;

                }
                else
                {
                    res.msg = "更新失败";
                    res.ResultCode = -1;
                }
            }
            catch (Exception)
            {
                res.msg = "服务器正忙。。。";
                res.ResultCode = -1;
            }
            return Ok(res);
        }

        /// <summary>
        /// 获取备忘录数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMemoData(int accountId)
        {
            var dbContent = db.WaitInfos.Where(x => x.AccountId == accountId).ToList();
            var memoList = mapper.Map<List<MemoInfoDTO>>(dbContent);
            ApiResponse res = new ApiResponse()
            {
                ResultCode = 200,
                msg = "获取成功",
                ResultData = memoList,
            };
            return Ok(res);
        }
        /// <summary>
        /// 添加备忘录数据
        /// </summary>
        /// <param name="memoInfoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMemoData(MemoInfoDTO memoInfoDTO)
        {
            var res = new ApiResponse();
            try
            {
                var memoInfo = mapper.Map<MemoInfo>(memoInfoDTO);
                var add = db.Add(memoInfo);
                int row = db.SaveChanges();
                if (row >= 0)
                {
                    res.msg = "添加成功";
                    res.ResultCode = 200;
                }
                else
                {
                    res.msg = "添加失败";
                    res.ResultCode = -1;
                }
            }
            catch (Exception)
            {
                res.msg = "服务器正忙。。。";
                res.ResultCode = -1;
            }
            return Ok(res);
        }

        /// <summary>
        /// 更新待办
        /// </summary>
        /// <param name="memoInfoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateMemoData(MemoInfoDTO memoInfoDTO)
        {
            var res = new ApiResponse();
            try
            {
                var memoInfo = mapper.Map<MemoInfo>(memoInfoDTO);
                var update = db.Update(memoInfo);
                int row = db.SaveChanges();
                if (row >= 0)
                {
                    res.msg = "更新成功";
                    res.ResultCode = 200;

                }
                else
                {
                    res.msg = "更新失败";
                    res.ResultCode = -1;
                }
            }
            catch (Exception)
            {
                res.msg = "服务器正忙。。。";
                res.ResultCode = -1;
            }
            return Ok(res);
        }

        /// <summary>
        /// 获取待办统计数据
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetStatWaitData(int accountId)
        {
            var dbContent = db.WaitInfos.Where(x=>x.AccountId == accountId).ToList();
            StatWaitDTO statWait = new StatWaitDTO()
            {
                TotalCount = dbContent.Count,
                FinishCount = dbContent.Where(x => x.Status == 1).Count(),
            };
            ApiResponse res = new ApiResponse()
            {
                ResultCode = 200,
                msg = "获取成功",
                ResultData = statWait,
            };
            return Ok(res);
        }
    }
}
