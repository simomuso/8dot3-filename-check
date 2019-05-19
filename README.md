# 8dot3-filename-check
A tool that allows you to check if a drive supports 8.3 file naming.
It simply wraps the fsutil command with *8dot3name* parameters.

# How it works
1. Download the tool: [8dot3FileNameCheck.exe](https://drive.google.com/open?id=1CtC2LqEHneYew-j4HLOhs3ZZUsmYQYUA)
2. Run "8dot3FileNameCheck.exe *drive letter*:" in a Windows CMD Line
3. If necessary or UAC is enabled, will be asked to run the executable As Administator.

For instance, if the drive that you want to check is C:, the correct wat to use the tool is:
8dot3FilenameCheck.exe C:

If the drive supports 8.3 file naming, a success messagge will appear in the CMD window.

# What to know
- Capital/lower cases for drives are supported
- A log file containing the check command result will be created in the same executable folder
- Source code is present and can be used freely



