using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.SecurityUtil
{
    public static class ImageValidator
    {
        public static bool IsImage(this IFormFile? file)
        {
            if (file == null) return false;
            try
            {
                var img = Image.FromStream(file.OpenReadStream());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
