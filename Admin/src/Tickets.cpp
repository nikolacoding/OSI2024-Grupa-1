#include "RemoveRenameFile.h"
#include "CreateDelete.h"
#include <iostream>
#include <fstream>
#include <cstdio>
#include <string>

void closeTicket(const std::string &accountName)
{
    std::ifstream inputFile(TICKETS_FILE);
    if (!inputFile) 
    {
        std::cerr << "Error: Unable to open the file.\n";
        return;
    }

    std::ofstream tempFile("../../Data/TempTickets.txt", std::ios::out);
    if (!tempFile) 
    {
        std::cerr << "Error: Unable to open the temporary file.\n";
        inputFile.close();
        return;
    }

    std::string fileLine;
    std::string clientLine= "CLIENT=" + accountName;
    int currentLine = 0;
    bool foundClient = false;

    while (std::getline(inputFile, fileLine)) 
    {
        if (fileLine == clientLine) 
        {
            foundClient = true;
            tempFile << fileLine << "\n";
        } 
        else if (foundClient && fileLine.find("STATUS=") != std::string::npos) 
        {
            tempFile << "STATUS=Zatvoren\n"; 
        } else {
            tempFile << fileLine << "\n";  
        }
    }

    if(!foundClient)std::cout<<"Klijent nema otvorenih tiketa\n";
    else std::cout<<"Svi tiketi su zatvoreni\n";

    inputFile.close();
    tempFile.close();

    removeFile(TICKETS_FILE);

    const char* oldName = "../../Data/TempTickets.txt";
    renameFile(TICKETS_FILE,oldName); 
}

void reassignOperatorTasks(const std::string& oldOperator,const std::string& fileTicket,const std::string& filePath)
{
    std::ifstream inputOperatorFile(filePath);
    if (!inputOperatorFile) 
    {
        std::cout << "Error: Unable to open tasks file.\n";
        return;
    }


    std::ifstream inputTicketFile(fileTicket);
    if (!inputTicketFile) 
    {
        std::cout << "Error: Unable to open tasks file.\n";
        return;
    }

    std::ofstream tempFile("../../Data/TempTasks.txt", std::ios::app);
    if (!tempFile) 
    {
        std::cout << "Error: Unable to open temporary tasks file.\n";
        inputTicketFile.close();
        return;
    }

    std::string ticketLine;
    bool tasksReassigned = false;
    std::string operatorLine;
    std::string newOperator = "";

    while (std::getline(inputTicketFile, ticketLine)) 
    {
        if (ticketLine.find("ASSIGNED_OPERATOR=" + oldOperator) != std::string::npos) 
        {
            tasksReassigned = true;

            while(std::getline(inputOperatorFile,operatorLine))
            {
                for (int i = 0; i < operatorLine.length(); ++i) 
                {
                    char ch = operatorLine[i];
                    if (ch == ':') break;
                    newOperator += ch;
                }
                tempFile<<"ASSIGNED_OPERATOR="<<newOperator<<"\n";
            }
        }
        else
        {
            tempFile << ticketLine << std::endl;
        }
    }

    inputOperatorFile.close();
    inputTicketFile.close();
    tempFile.close();

    if (!tasksReassigned) 
    {
        std::cout << "Operator nema tiketa: " << oldOperator << std::endl;
        return;
    }

    removeFile(fileTicket);
    renameFile(fileTicket, "../../Data/TempTasks.txt");

    std::cout << "Svi tiketi operatera " << oldOperator << " su prebaceni operateru "<<newOperator<< "\n";
}

void activeTickets(const std::string& accountName)
{
    std::ifstream inputFile(TICKETS_FILE);
    if (!inputFile)
    {
        std::cout << "Error: Unable to open tasks file.\n";
        return;
    }

    std::string line;
    std::string client="", title="", content="", assignedOperator="", status="", operatorResponse="";

    while(!inputFile.eof())
    {
        while (std::getline(inputFile, line))
        {
            if(line.find("CLIENT=") != std::string::npos)
            {
                client=line;
            }
            else if(line.find("TITLE=") != std::string::npos)
            {
                title=line;
            }
            else if(line.find("CONTENT=") != std::string::npos)
            {
                content=line;
            }
            else if(line.find("ASSIGNED_OPERATOR=") != std::string::npos)
            {
                assignedOperator=line;
            }
            else if(line.find("STATUS=") != std::string::npos)
            {
                status=line;
            }
            else if(line.find("OPERATOR_RESPONSE=") != std::string::npos)
            {
                operatorResponse=line;
            }
            else if(line.size()==0)
            {
                break;
            }
        }
        if(accountName==assignedOperator.substr(18) && status.substr(7)=="Otvoren")
        {
            std::cout<<client<<std::endl
            <<title<<std::endl
            <<content<<std::endl
            <<assignedOperator<<std::endl
            <<status<<std::endl
            <<operatorResponse<<std::endl
            <<"---------------------------------\n";
        }
    }

    inputFile.close();
}

void ticketReview(const std::string& filePath)
{
    std::ifstream inputFile(filePath);
    if(!inputFile)
    {
        std::cout<<"Error:Unable to open tasks file.\n";
        return;
    }

    std::string line;
    while(std::getline(inputFile,line))
    {
        std::cout<<line<<std::endl;
    }
}

