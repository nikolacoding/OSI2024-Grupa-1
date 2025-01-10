#include "LoginForm.h"

LoginData LoginForm::Login(){
    std::string username;
    LoginData data;
    do {
        std::cout << "Unesi korisnicko ime: ";
        std::cin >> username;
    } while (!FileManager::GetUserData(ADMIN_ACCOUNTS_FILE_PATH, username, data));

    std::string passwordAttempt;

    do{
        std::cout << "Unesi lozinku za " << data.username << ": ";
        std::cin >> passwordAttempt; 
    }
    while (passwordAttempt != data.password);
    std::cout << "Prijava uspjesna!" << std::endl;
    return data;
}