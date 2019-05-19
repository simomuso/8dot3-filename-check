using System.IO;

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
                if (d.Name.ToLower().Contains(drive.ToLower()) && d.DriveType != DriveType.CDRom)
                    return true;
            }

            return false;
        }
    }
}
