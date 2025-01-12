#pragma once

#include <iostream>

const std::string CLIENT_FILE = "../../Data/UserAccounts.txt";
const std::string OPERATOR_FILE = "../../Data/OperatorAccounts.txt";
const std::string TICKETS_FILE = "../../Data/Tickets.txt";
const std::string ARCHIVED_TICKETS_FILE = "../../Data/ArchivedTickets.txt";

bool login(std::string &);