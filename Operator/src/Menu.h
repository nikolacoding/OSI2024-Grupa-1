
#include <string>
#include <vector>

class Menu {
private:
    std::string operatorName;
    std::vector<std::string> tickets;

public:
    Menu(const std::string& name, const std::vector<std::string>& ticketList);
    void displayMenu() const;
    void runMenu();
};


