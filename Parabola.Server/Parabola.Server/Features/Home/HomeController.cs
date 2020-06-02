namespace Parabola.Server.Features.Home
{
    using Parabola.Server.Features.Home.Models;
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;


    [Route("[controller]")]
    public class HomeController : ApiController
    {
        IChartService ChartService = new ChartService();

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route(nameof(Parabola))]
        public async Task<object> Parabola(ParaboleModel model)
        {
            if (ModelState.IsValid)
            {
                double disc = Math.Pow(model.b, 2) - (4 * model.a * model.c);

                var userdata = await ChartService.AddUserData(model);

                if (disc >= 0)
                {
                    var points = await ChartService.Points(model, userdata);

                    return points;
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Введенные данные должны быть целыми числами");

                return ModelState;
            }

                return null;

        }
        
    }
}
