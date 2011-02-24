REM Copy newer files to the U drive
REM Excludes all OBJ and BIN folders
robocopy.exe . "U:\My Documents\Home\My Stuff\XNA\3DModelPrep" /MIR /XO /XD obj bin .svn *.user *.suo *.cachefile
