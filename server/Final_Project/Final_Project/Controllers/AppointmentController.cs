using Final_Project.Dal.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Final_Project.BL.Services;


namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        // יצירת מופע של שכבת הלוגיקה (בצורה פשוטה לבינתיים)
        // הערה: אם חברה שלך הגדירה Dependency Injection, נשתמש בזה אחרת
        private readonly UserServiceBL _userService = new UserServiceBL();

        // הפונקציה שתחזיר היסטוריית תורים לפי ID של משתמש
        [HttpGet("history/{userId}")]
        public IActionResult GetHistory(int userId)
        {
            try
            {
                // קריאה לפונקציה שכתבת ב-BL
                var history = _userService.GetUserHistory(userId);

                if (history == null)
                {
                    return NotFound("לא נמצאה היסטוריה למשתמש זה");
                }

                return Ok(history); // מחזיר JSON של הרשימה עם קוד 200
            }
            catch (Exception ex)
            {
                return BadRequest("שגיאה: " + ex.Message);
            }
        }
    }
}
