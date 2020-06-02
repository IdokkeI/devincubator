namespace Parabola.Server.Features.Home
{
    using Parabola.Server.Data;
    using Parabola.Server.Features.Home.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IChartService
    {
        Task<UserData> AddUserData(ParaboleModel model);

        Task<Dictionary<double, double>> Points(ParaboleModel model, UserData userdata);
    }
}