#include "MainLoop.h"

void MainLoop::Start(){
    LoginData data = LoginForm::Login();
    Menu menu(data.username);
    
    std::vector<TicketData> tickets;
    std::vector<std::string> operators;
    std::vector<std::string> clients;

    menu.show();

    // 1 - Lista aktivnih tiketa
    // 2 - Lista operatera
    // 3 - Lista klijenata
    // 4 - Menadzment naloga
    // 5 - Menadzment tiketa
    int choice = -1;
    std::string stringChoice;
    int secondaryChoice = -1;
    
    while (choice != 0){
        std::cin >> choice;
        menu.wipe();

        switch(choice){
            case 0: {
                std::cout << "Izlazimo..." << std::endl;
                return;
            }
            break;

            case 1: {
                std::cout << "Lista tiketa:" << std::endl;
                tickets = FileManager::GetAllTickets();
                for (const auto& t : tickets)
                    t.displayShort();
            }
            break;

            case 2: {
                operators = FileManager::GetAllOperators();
                std::cout << "Lista operatera:" << std::endl;
                for (const auto& o : operators)
                    std::cout << o << std::endl;
            }
            break;

            case 3: {
                clients = FileManager::GetAllClients();
                std::cout << "Lista klijenata:" << std::endl;
                for (const auto& c : clients)
                    std::cout << c << std::endl;
            }
            break;

            case 4: {
                std::cout << "Vrsta naloga:\n1 - Klijentski\n2 - Operaterski\n3 - Administratorski\nIzbor: ";
                std::cin >> secondaryChoice;

                // odabir datoteke
                std::filesystem::path finalPath;    
                if (secondaryChoice == 1)
                    finalPath = CLIENT_ACCOUNTS_FILE_PATH;
                else if (secondaryChoice == 2)
                    finalPath = OPERATOR_ACCOUNTS_FILE_PATH;
                else if (secondaryChoice == 3)
                    finalPath = ADMIN_ACCOUNTS_FILE_PATH;
                else{
                    std::cout << "Izbor nije validan." << std::endl;
                    break;
                }

                std::cout << "Izaberi nalog po imenu: ";
                std::cin >> stringChoice;
                LoginData data;

                // provjera validnosti trazenog naloga u navedenoj datoteci
                if (FileManager::GetUserData(finalPath, stringChoice, data)){
                    int tertiaryChoice;
                    std::string newCred;
                    std::cout << "Promijeniti:\n1 - Ime\n2 - Lozinku\nIzbor: ";
                    std::cin >> tertiaryChoice;

                    // izbor izmedju promjene imena ili lozinke
                    if (tertiaryChoice != 1 && tertiaryChoice != 2){
                        std::cout << "Izbor nije validan." << std::endl;
                        break;
                    }
                    else{
                        std::cout << "Novo: ";
                        std::cin >> newCred;
                        
                        if (tertiaryChoice == 1)
                            FileManager::ChangeAttributeName(finalPath, data.username, newCred, ':');
                        else if (tertiaryChoice == 2)
                            FileManager::ChangeAttributeValue(finalPath, data.username, newCred, ':');
                        std::cout << "Uspjesno promijenjeno." << std::endl;
                    }
                }
                else{
                    std::cout << "Nalog '" << stringChoice << "' nije pronadjen." << std::endl;
                }
            }
            break;

            case 5: {
                std::cout << "Vrsta naloga:\n1 - Klijentski\n2 - Operaterski\n3 - Administratorski\nIzbor: ";
                std::cin >> secondaryChoice;

                std::filesystem::path finalPath;    
                if (secondaryChoice == 1)
                    finalPath = CLIENT_ACCOUNTS_FILE_PATH;
                else if (secondaryChoice == 2)
                    finalPath = OPERATOR_ACCOUNTS_FILE_PATH;
                else if (secondaryChoice == 3)
                    finalPath = ADMIN_ACCOUNTS_FILE_PATH;
                else{
                    std::cout << "Izbor nije validan." << std::endl;
                    break;
                }

                int tertiaryChoice;
                std::cout << "Akcija:\n1 - Kreirati nalog\n2 - Obrisati nalog\nIzbor: ";
                std::cin >> tertiaryChoice;

                if (tertiaryChoice != 1 && tertiaryChoice != 2){
                    std::cout << "Izbor nije validan." << std::endl;
                    break;
                }
                else if (tertiaryChoice == 1){
                    std::string newUsername, newPassword;

                    std::cout << "Korisnicko ime: ";
                    std::cin >> newUsername;

                    std::cout << "Lozinka: ";
                    std::cin >> newPassword;

                    FileManager::AppendToFile(finalPath, newUsername, newPassword, ':');

                    std::cout << "Uspjesno kreiran nalog '" + newUsername << ':' << newPassword << "'." << std::endl;
                    break;
                }
                else if (tertiaryChoice == 2){
                    std::string usernameToDelete;
                    
                    std::cout << "Unesi korisnicko ime naloga za brisanje: ";
                    std::cin >> usernameToDelete;
                    
                    LoginData ph;
                    if (FileManager::GetUserData(finalPath, usernameToDelete, ph))
                        FileManager::DeleteAttributeByName(finalPath, usernameToDelete, ':');
                    
                    std::cout << "Uspjesno obrisan nalog '" + ph.username << ':' << ph.password << "'." << std::endl;
                    break;
                }
            }
            break;
        }
        menu.show();
    }
}