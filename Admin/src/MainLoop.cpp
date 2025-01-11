#include "MainLoop.h"

void MainLoop::Run(){
    LoginData data = LoginForm::Login();

RELOAD:
    Menu menu(data.username);
    
    FunctionalStats fs = FileManager::GetFunctionalStats();

    menu.show();

    //X "1 - Lista aktivnih tiketa",
    //X "2 - Detaljan pregled tiketa",
    //X "3 - Lista operatera",
    //X "4 - Lista klijenata",
    //X "5 - Promjena podataka naloga",
    //X "6 - Kreiranje/brisanje naloga",
    // "7 - Menadzment tiketa",
    // "8 - Pregled statistike",
    //X "9 - Aktivacija komercijalne verzije", *** ukoliko nije vec aktivirana
    // "0 - Izlaz"

    int choice = -1;
    std::string stringChoice;
    int secondaryChoice = -1;
    
    while (choice != 0){
        std::cin >> choice;
        menu.wipe();

        switch(choice){
            
            // Izlaz
            case 0: {
                std::cout << "Izlazimo..." << std::endl;
                return;
            }
            break;

            // Lista aktivnih tiketa
            case 1: DisplayShortTicketList(); break;

            // Detaljan pregled tiketa
            case 2: DetailedTicketDisplay(); break;

            // Lista operatera
            case 3: DisplayAllOperators(); break;

            // Lista klijenata
            case 4: DisplayAllClients(); break;

            // Promjena podataka naloga
            case 5: ModifyAccountData(); break;

            // Kreiranje/brisanje naloga
            case 6: CreateDeleteAccounts(menu); break;

            // Menadzment tiketa
            case 7: {

            }

            // Pregled statistike
            case 8: DisplayStats(); break;

            // Aktivacija komercijalne verzije
            case 9: ActivatePaidVersion(menu); break;

            // Nevalidna opcija
            default: InvalidOptionHandler(); break;
        }
        menu.show();
    }
}

void MainLoop::DisplayShortTicketList(){
    std::vector<TicketData> tickets;
    std::cout << "Lista tiketa:" << std::endl;
    tickets = FileManager::GetAllTickets();
    for (const auto& t : tickets)
        t.displayShort();
}

void MainLoop::DetailedTicketDisplay(){
    std::string stringChoice;
    std::vector<TicketData> tickets;

    std::cout << "Ime klijenta autora: " << std::endl;
    std::cin >> stringChoice;

    tickets = FileManager::GetAllTickets();
    auto it = std::find_if(tickets.begin(), tickets.end(), [&stringChoice](const TicketData& td){
        return td.clientName == stringChoice;
    });

    if (it == tickets.end()){
        std::cout << "Navedeni autor nema aktivnih tiketa." << std::endl;
        return;
    }
    else{
        const TicketData& foundTicket = *it;
        std::cout << "Detaljan opis tiketa autora [" << stringChoice << "]:" << std::endl;
        foundTicket.display();
        return;
    }
}

void MainLoop::DisplayAllOperators(){
    std::vector<std::string> operators;
    operators = FileManager::GetAllOperators();

    std::cout << "Lista operatera:" << std::endl;
    for (const auto& o : operators)
        std::cout << o << std::endl;
}

void MainLoop::DisplayAllClients(){
    std::vector<std::string> clients;
    clients = FileManager::GetAllClients();

    std::cout << "Lista klijenata:" << std::endl;
    for (const auto& c : clients)
        std::cout << c << std::endl;
}

void MainLoop::ModifyAccountData(){
    int secondaryChoice, tertiaryChoice;
    std::string stringChoice;
    
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
        return;
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
            return;
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

void MainLoop::CreateDeleteAccounts(const Menu& menu){
    int secondaryChoice, tertiaryChoice;
    FunctionalStats fs = FileManager::GetFunctionalStats();

    std::cout << "Vrsta naloga:\n1 - Klijentski\n2 - Operaterski\n3 - Administratorski\nIzbor: ";
    std::cin >> secondaryChoice;

    std::filesystem::path finalPath;    
    if (secondaryChoice == 1)
        finalPath = CLIENT_ACCOUNTS_FILE_PATH;
    else if (secondaryChoice == 2){
        if (!menu.isPaid() && fs.numOperatorAccounts >= MAX_FREE_OPERATOR_ACCOUNTS){
            std::printf("Dostignut je maksimalan broj [%d] operaterskih naloga za besplatnu verziju.", MAX_FREE_OPERATOR_ACCOUNTS);
            std::cout << " Aktivirati komercijalnu verziju za uklanjanje ovog ogranicenja." << std::endl;
            return;
        }
        finalPath = OPERATOR_ACCOUNTS_FILE_PATH;
    }
    else if (secondaryChoice == 3){
        if (!menu.isPaid() && fs.numAdminAccounts >= MAX_FREE_ADMIN_ACCOUNTS){
            std::printf("Dostignut je maksimalan broj [%d] administratorskih naloga za besplatnu verziju.", MAX_FREE_ADMIN_ACCOUNTS);
            std::cout << " Aktivirati komercijalnu verziju za uklanjanje ovog ogranicenja." << std::endl;
            return;
        }
        finalPath = ADMIN_ACCOUNTS_FILE_PATH;
    }
    else{
        std::cout << "Izbor nije validan." << std::endl;
        return;
    }

    std::cout << "Akcija:\n1 - Kreirati nalog\n2 - Obrisati nalog\nIzbor: ";
    std::cin >> tertiaryChoice;

    if (tertiaryChoice != 1 && tertiaryChoice != 2){
        std::cout << "Izbor nije validan." << std::endl;
        return;
    }
    else if (tertiaryChoice == 1){
        std::string newUsername, newPassword;

        std::cout << "Korisnicko ime: ";
        std::cin >> newUsername;

        std::cout << "Lozinka: ";
        std::cin >> newPassword;

        FileManager::AppendToFile(finalPath, newUsername, newPassword, ':');

        std::cout << "Uspjesno kreiran nalog '" + newUsername << ':' << newPassword << "'." << std::endl;
        return;
    }
    else if (tertiaryChoice == 2){
        std::string usernameToDelete;
        
        std::cout << "Unesi korisnicko ime naloga za brisanje: ";
        std::cin >> usernameToDelete;
        
        LoginData ph;
        if (FileManager::GetUserData(finalPath, usernameToDelete, ph))
            FileManager::DeleteAttributeByName(finalPath, usernameToDelete, ':');
        
        std::cout << "Uspjesno obrisan nalog '" + ph.username << ':' << ph.password << "'." << std::endl;
        return;
    }
}

void MainLoop::DisplayStats(){
    DisplayableStats ds = FileManager::GetDisplayableStats();
    ds.display();
}

void MainLoop::ActivatePaidVersion(const Menu& menu){
    if (menu.isPaid()){
        InvalidOptionHandler();
        return;
    }

    std::string stringChoice;

    std::cout << "Unesi kljuc za aktivaciju: ";
    std::cin >> stringChoice;

    if (FileManager::TryActivatingPaidVersion(stringChoice)){
        FileManager::ChangeAttributeValue(GLOBAL_DATA_FILE_PATH, "PAIDVERSION", "1");
        std::cout << "Uspjesno aktiviranje komercijalne verzije. " << 
            "Ovo zahtijeva ponovno pokretanje sistema." << std::endl;
        // TODO; rijesiti ovo
    }
    else{
        std::cout << "Uneseni kljuc je neispravan." << std::endl;
        return;
    }
}

void MainLoop::InvalidOptionHandler(){
    std::cout << "Unesena opcija nije validna." << std::endl;
}