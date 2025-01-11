#include "FileManager.h" 

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
        if (currentLine[0] == 'C' && currentLine[1] == 'L'){
            data.push_back(GetTicketData(GetAttributeValue(currentLine)));
        }
    }

    stream.clear();
    return data;
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