#pragma once

void closeTicket(const std::string &accountName);
void reassignOperatorTasks(const std::string& oldOperator,const std::string& fileTicket,const std::string& filePath);
void activeTickets(const std::string& accountName);
void ticketReview(const std::string& filePath);