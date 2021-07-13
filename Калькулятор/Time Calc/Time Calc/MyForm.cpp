//¬ариант 17(14). »нтервалы  времени (задаютс€ в часах, минутах, секундах).
//¬вод данных, ввод только в часах, минутах или секундах, нахождение величины временного интервала, суммы,
//разности, преобразование интервала в часы, минуты, секунды.

#include "MyForm.h"

using namespace System;
using namespace System::Windows::Forms;


[STAThread]
void main(array<String^>^ arg) {
    Application::EnableVisualStyles();
    Application::SetCompatibleTextRenderingDefault(false);
    Project1::MyForm form; //WinFormsTest - им€ вашего проекта
    Application::Run(% form);
}


