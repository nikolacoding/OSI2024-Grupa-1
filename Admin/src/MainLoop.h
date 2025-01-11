#ifndef MAINLOOP_H
#define MAINLOOP_H

#include <algorithm>

#include "Data.h"
#include "LoginForm.h"
#include "Menu.h"
#include "Stats.h"

namespace MainLoop {
    void Run();

    static void DisplayShortTicketList();
    static void DetailedTicketDisplay();
    static void DisplayAllOperators();
    static void DisplayAllClients();
    static void ModifyAccountData();
    static void CreateDeleteAccounts(const Menu& menu);
    static void ManageTickets();
    static void DisplayStats();
    static void AssignTicketsToOperators();
    static void ActivatePaidVersion(const Menu& menu);
    static void InvalidOptionHandler();
};

#endif