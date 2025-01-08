#include <iostream>
#include <fstream>
#include <cstdio>

void removeFile(const std::string& filePath)
{
    if (std::remove(filePath.c_str()) != 0)
    {
        std::cerr << "Error: Unable to delete the file.\n";
    }
}

void renameFile(const std::string& newName,const char* oldName)
{
    if (std::rename(oldName,newName.c_str()) != 0)
    {
         std::cerr << "Error: Unable to rename the file.\n";
    }
}