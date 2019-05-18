using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface IDrivesChecker
    {
        bool IsDriveInstalled(string drive);
    }

    public class DrivesChecker : IDrivesChecker
    {
        public bool IsDriveInstalled(string drive)
        {
            var avalDrives = DriveInfo.GetDrives();
            foreach (var d in avalDrives)
            {
                if (d.Name.ToLower().Contains(drive) && d.DriveType != DriveType.CDRom)
                    return true;
            }

            return false;
        }
    }
}
