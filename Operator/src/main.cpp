#include "Menu.h"
#include "Operator.h"
#include "Data.h"
#include <vector>
#include "FileManager.h"

int main() {
      std :: string operatorName;
 
      if(!login(operatorName)){
        std :: cout << "Prijava nije uspjela. Pokusajte ponovo.\n";
        return 1;
      }

         std::vector<TicketData> tickets = FileManager :: GetAllTickets();
        Menu menu(operatorName,  tickets);
        
      while(true){
        menu.displayMenu();
        std :: cout << "Unesite izbor:";
        int choice;
        std :: cin >> choice;

        if(choice==0){
            std:: cout << "Izlaz\n";
            break;
        }

        menu.runMenu();
      }
      
      return 0;
}

