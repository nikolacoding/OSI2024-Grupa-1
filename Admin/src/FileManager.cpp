#include "FileManager.h"

bool FileManager::GetUserData(const std::filesystem::path& filename, const std::string& username, LoginData& data) {
    std::ifstream stream(filename);

    std::string currentLine;
    while (std::getline(stream, currentLine)){
        std::string currentUsername = "";
        std::string currentPassword = "";

        bool flag = false;
        for (size_t i = 0; i < currentLine.size(); i++){
            char currentChar = currentLine[i];
            if (currentChar == ':'){
                flag = true;
                continue;
            }
            if (!flag)
                currentUsername += currentChar;
            else
                currentPassword += currentChar;
        }

        if (username == currentUsername){
            data.username = currentUsername;
            data.password = currentPassword;
            stream.close();
            return true;
        }
    }
    
    stream.close();
    std::cout << "Uneseno korisnicko ime nije pronadjeno." << std::endl;
    return false;
}

std::vector<std::string> FileManager::ReadAllLines(const std::filesystem::path& filepath){
    std::vector<std::string> ret;
    std::ifstream stream(filepath);

    std::string currentLine;
    while (std::getline(stream, currentLine))
        ret.push_back(currentLine);
    
    stream.close();
    return ret;
}

void FileManager::WriteAllLines(const std::filesystem::path& filepath, const std::vector<std::string>& lines){
    std::ofstream stream(filepath);

    for (const auto& l : lines)
        stream << l << std::endl;

    stream.close();
}

TicketData FileManager::GetTicketData(const std::string& username){
    std::ifstream stream(TICKETS_FILE_PATH);

    std::string currentLine;

    TicketData data;
    const size_t numRelevantLines = 6;
    std::vector<std::string> relevantLines;
    relevantLines.resize(numRelevantLines);

    while (std::getline(stream, currentLine)){
        if (GetAttributeValue(currentLine) == username){
            relevantLines[0] = GetAttributeValue(currentLine); // ime
            for (size_t i = 1; i < numRelevantLines; i++){
                std::getline(stream, currentLine);
                relevantLines[i] = GetAttributeValue(currentLine);
            }

            data.clientName = relevantLines[0];
            data.title = relevantLines[1];
            data.content = relevantLines[2];
            data.assignedOperatorName = relevantLines[3];
            data.status = relevantLines[4];
            data.operatorResponse = relevantLines[5];
        }
    }

    stream.close();
    return data;
}

std::vector<TicketData> FileManager::GetAllTickets(){
    std::vector<TicketData> data;

    std::ifstream stream(TICKETS_FILE_PATH);
    std::string currentLine;

    while (std::getline(stream, currentLine)){
        if (GetAttributeName(currentLine, '=') == "CLIENT"){
            data.push_back(GetTicketData(GetAttributeValue(currentLine)));
        }
    }

    stream.clear();
    return data;
}

std::vector<std::string> FileManager::GetAllOperators(){
    std::vector<std::string> ret;

    std::ifstream stream(OPERATOR_ACCOUNTS_FILE_PATH);
    
    std::string currentLine;
    while (std::getline(stream, currentLine))
        ret.push_back(GetAttributeName(currentLine, ':'));
    
    stream.close();
    return ret;
}

std::vector<std::string> FileManager::GetAllClients(){
    std::vector<std::string> ret;

    std::ifstream stream(CLIENT_ACCOUNTS_FILE_PATH);
    
    std::string currentLine;
    while (std::getline(stream, currentLine))
        ret.push_back(GetAttributeName(currentLine, ':'));
    
    stream.close();
    return ret;
}

bool FileManager::CheckPaidVersion(){
    std::ifstream stream(GLOBAL_DATA_FILE_PATH);
    
    std::string currentLine;
    while (std::getline(stream, currentLine)){
        if (GetAttributeName(currentLine, '=') == "PAIDVERSION")
            return std::stoi(GetAttributeValue(currentLine, '='));
    }

    stream.close();
    return false;
}

bool FileManager::TryActivatingPaidVersion(const std::string& attemptedKey){
    std::ifstream stream(KEYS_FILE_PATH);

    std::string currentLine;
    while (std::getline(stream, currentLine)){
        if (currentLine == attemptedKey)
            return true;
    }
    
    stream.close();
    return false;
}

const std::string FileManager::GetFirmName(){
    std::ifstream stream(GLOBAL_DATA_FILE_PATH);

    std::string currentLine;
    while (std::getline(stream, currentLine)){
        if (GetAttributeName(currentLine) == "FIRMNAME")
            return GetAttributeValue(currentLine);
    }
    
    return "";
}

std::string FileManager::GetAttributeName(const std::string& attributeString, char separator) {
    std::string ret = "";

    for (size_t i = 0; i < attributeString.size(); i++){
        char currentChar = attributeString[i];
        if (currentChar == separator)
            break;
        
        ret += currentChar;
    }

    return ret;
}

std::string FileManager::GetAttributeValue(const std::string& attributeString, char separator) {
    std::string ret = "";

    bool passedSeparator = false;
    for (size_t i = 0; i < attributeString.size(); i++){
        char currentChar = attributeString[i];

        if (passedSeparator){
            ret += currentChar;
            continue;
        }

        if (currentChar == separator)
            passedSeparator = true;
    }

    return ret;
}

void FileManager::ChangeAttributeName(const std::filesystem::path& filepath, 
    const std::string& attributeName, const std::string& newName, char separator){
    auto lines = ReadAllLines(filepath);

    for (auto& l : lines){
        if (GetAttributeName(l, separator) == attributeName){
            std::string val = GetAttributeValue(l, separator);
            l = newName + separator + val;
            break;
        }
    }

    WriteAllLines(filepath, lines);
}

void FileManager::ChangeAttributeValue(const std::filesystem::path& filepath, 
    const std::string& attributeName, const std::string& newValue, char separator){

    auto lines = ReadAllLines(filepath);

    for (auto& l : lines){
        if (GetAttributeName(l, separator) == attributeName){
            l = attributeName + separator + newValue;
            break;
        }
    }

    WriteAllLines(filepath, lines); 
}

void FileManager::DeleteAttributeByName(const std::filesystem::path& filepath,
    const std::string& attributeName, char separator){
    
    auto lines = ReadAllLines(filepath);
    std::vector<std::string> modLines;
    
    for (const auto& l : lines){
        if (GetAttributeName(l, separator) == attributeName)
            continue;
        modLines.push_back(l);
    }

    WriteAllLines(filepath, modLines);
}

void FileManager::AppendToFile(const std::filesystem::path& filepath,
    const std::string& attributeName, const std::string& attributeValue, char separator){
    
    std::ofstream stream;
    stream.open(filepath, std::ios_base::app); // otvaranje u append rezimu
    stream << attributeName << separator << attributeValue;
    stream.close();
}