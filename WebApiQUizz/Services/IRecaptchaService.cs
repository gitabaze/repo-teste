using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiQUizz.Services
{
  public   interface IRecaptchaService
    {
        string ValidateInvOkeRecaptcha();
    }
}
