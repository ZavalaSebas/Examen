﻿using FrontEnd.Models;
using System.Collections.Generic;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IDistritoHelper
    {
        List<DistritoViewModel> GetDistritos();
        DistritoViewModel GetDistrito(int id);
        DistritoViewModel AddDistrito(DistritoViewModel distrito);
        DistritoViewModel DeleteDistrito(int id);
        DistritoViewModel UpdateDistrito(DistritoViewModel distrito);
    }
}
