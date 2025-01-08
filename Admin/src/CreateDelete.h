#pragma once

#include <string>

const std::string CLIENT_FILE = "../../Data/UserAccounts.txt";
const std::string ADMIN_FILE = "../../Data/AdminAccounts.txt";
const std::string OPERATOR_FILE = "../../Data/OperatorAccounts.txt";
const std::string TICKETS_FILE = "../../Data/Tickets.txt";

void createAccount(const std::string& filePath, const std::string& accountName, const std::string& password);
void deleteAccount(const std::string& filePath);
void closeTicket(const std::string& accountName);
