using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Constants;

public class EmailTemplate
{
    public const string OTP_CODE_SUBJECT = "OTP Code";
    public const string OTP_CODE_BODY = "Hi,<br/><br/>Your OTP Code is {0}";
}
