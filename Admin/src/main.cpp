#include <iostream>
#include <exception>

#include "MainLoop.h"

int main(void){
    try{
        MainLoop::Run();
    } catch (const std::exception& e){
        std::cout << e.what() << std::endl;
        return EXIT_FAILURE;
    }

    return EXIT_SUCCESS;
}