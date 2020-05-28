#pragma once
#include <string>
#include "clsTime.h"

namespace Project1 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:

		MyForm(void)
		{
			InitializeComponent();

			//----------------------------------------------------------------
			InitTime();
			TXT_main_h->Focus();
			Set_active(TXT_main_h);
			InitTXTfocus();
			//----------------------------------------------------------------
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::TextBox^ TXT_main_h;
	protected:



	private: System::Windows::Forms::Button^ button0;
	private: System::Windows::Forms::Button^ button1;
	private: System::Windows::Forms::Button^ button2;
	private: System::Windows::Forms::Button^ button3;
	private: System::Windows::Forms::Button^ button4;
	private: System::Windows::Forms::Button^ button5;
	private: System::Windows::Forms::Button^ button6;
	private: System::Windows::Forms::Button^ button7;
	private: System::Windows::Forms::Button^ button8;
	private: System::Windows::Forms::Button^ button9;

	private: System::Windows::Forms::Button^ BTN_point;

	private: System::Windows::Forms::Button^ BTN_add;
	private: System::Windows::Forms::Button^ BTN_minus;
	private: System::Windows::Forms::Button^ BTN_to_hour;
	private: System::Windows::Forms::Button^ BTN_to_min;
	private: System::Windows::Forms::Button^ BTN_to_sec;

	private: System::Windows::Forms::Button^ BTN_clear;
	private: System::Windows::Forms::TextBox^ TXT_main_m;
	private: System::Windows::Forms::TextBox^ TXT_main_s;

	private: System::Windows::Forms::Button^ BTN_equals;
	private: System::Windows::Forms::Button^ BTN_delete_last;

	private: System::Windows::Forms::TableLayoutPanel^ tableLayoutPanel1;
	private: System::Windows::Forms::TableLayoutPanel^ tableLayoutPanel2;
	private: System::Windows::Forms::TableLayoutPanel^ tableLayoutPanel3;
	private: System::Windows::Forms::Panel^ PNL_main_h;
	private: System::Windows::Forms::Panel^ PNL_main_s;
	private: System::Windows::Forms::Panel^ PNL_main_m;
	private: System::Windows::Forms::TextBox^ LOG;

	private: System::Windows::Forms::Panel^ panel5;
	private: System::Windows::Forms::Panel^ panel3;
	private: System::Windows::Forms::Panel^ panel4;

	private: System::Windows::Forms::TextBox^ LBL_main_h;
	private: System::Windows::Forms::TextBox^ LBL_main_s;
	private: System::Windows::Forms::TextBox^ LBL_main_m;

	protected:

	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^ resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->TXT_main_h = (gcnew System::Windows::Forms::TextBox());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->button5 = (gcnew System::Windows::Forms::Button());
			this->button6 = (gcnew System::Windows::Forms::Button());
			this->button7 = (gcnew System::Windows::Forms::Button());
			this->button8 = (gcnew System::Windows::Forms::Button());
			this->button9 = (gcnew System::Windows::Forms::Button());
			this->BTN_add = (gcnew System::Windows::Forms::Button());
			this->BTN_minus = (gcnew System::Windows::Forms::Button());
			this->BTN_to_hour = (gcnew System::Windows::Forms::Button());
			this->BTN_to_min = (gcnew System::Windows::Forms::Button());
			this->BTN_point = (gcnew System::Windows::Forms::Button());
			this->button0 = (gcnew System::Windows::Forms::Button());
			this->BTN_clear = (gcnew System::Windows::Forms::Button());
			this->TXT_main_m = (gcnew System::Windows::Forms::TextBox());
			this->TXT_main_s = (gcnew System::Windows::Forms::TextBox());
			this->BTN_to_sec = (gcnew System::Windows::Forms::Button());
			this->BTN_equals = (gcnew System::Windows::Forms::Button());
			this->BTN_delete_last = (gcnew System::Windows::Forms::Button());
			this->tableLayoutPanel1 = (gcnew System::Windows::Forms::TableLayoutPanel());
			this->tableLayoutPanel2 = (gcnew System::Windows::Forms::TableLayoutPanel());
			this->tableLayoutPanel3 = (gcnew System::Windows::Forms::TableLayoutPanel());
			this->PNL_main_s = (gcnew System::Windows::Forms::Panel());
			this->panel5 = (gcnew System::Windows::Forms::Panel());
			this->LBL_main_s = (gcnew System::Windows::Forms::TextBox());
			this->PNL_main_h = (gcnew System::Windows::Forms::Panel());
			this->panel3 = (gcnew System::Windows::Forms::Panel());
			this->LBL_main_h = (gcnew System::Windows::Forms::TextBox());
			this->PNL_main_m = (gcnew System::Windows::Forms::Panel());
			this->panel4 = (gcnew System::Windows::Forms::Panel());
			this->LBL_main_m = (gcnew System::Windows::Forms::TextBox());
			this->LOG = (gcnew System::Windows::Forms::TextBox());
			this->tableLayoutPanel1->SuspendLayout();
			this->tableLayoutPanel2->SuspendLayout();
			this->tableLayoutPanel3->SuspendLayout();
			this->PNL_main_s->SuspendLayout();
			this->panel5->SuspendLayout();
			this->PNL_main_h->SuspendLayout();
			this->panel3->SuspendLayout();
			this->PNL_main_m->SuspendLayout();
			this->panel4->SuspendLayout();
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button1->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button1->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->button1->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button1->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button1->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button1->Location = System::Drawing::Point(0, 160);
			this->button1->Margin = System::Windows::Forms::Padding(0);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(101, 80);
			this->button1->TabIndex = 0;
			this->button1->Text = L"1";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// TXT_main_h
			// 
			this->TXT_main_h->BackColor = System::Drawing::Color::Gainsboro;
			this->TXT_main_h->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->TXT_main_h->Dock = System::Windows::Forms::DockStyle::Top;
			this->TXT_main_h->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 25.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->TXT_main_h->Location = System::Drawing::Point(0, 0);
			this->TXT_main_h->Margin = System::Windows::Forms::Padding(0);
			this->TXT_main_h->MaxLength = 10;
			this->TXT_main_h->Name = L"TXT_main_h";
			this->TXT_main_h->RightToLeft = System::Windows::Forms::RightToLeft::Yes;
			this->TXT_main_h->Size = System::Drawing::Size(379, 58);
			this->TXT_main_h->TabIndex = 1;
			this->TXT_main_h->TextChanged += gcnew System::EventHandler(this, &MyForm::TXT_main_h_TextChanged);
			// 
			// button2
			// 
			this->button2->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button2->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button2->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->button2->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button2->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button2->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button2->Location = System::Drawing::Point(101, 160);
			this->button2->Margin = System::Windows::Forms::Padding(0);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(101, 80);
			this->button2->TabIndex = 2;
			this->button2->Text = L"2";
			this->button2->UseVisualStyleBackColor = false;
			this->button2->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// button3
			// 
			this->button3->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button3->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button3->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->button3->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button3->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button3->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button3->Location = System::Drawing::Point(202, 160);
			this->button3->Margin = System::Windows::Forms::Padding(0);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(101, 80);
			this->button3->TabIndex = 3;
			this->button3->Text = L"3";
			this->button3->UseVisualStyleBackColor = false;
			this->button3->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// button4
			// 
			this->button4->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button4->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button4->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->button4->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button4->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button4->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button4->Location = System::Drawing::Point(0, 80);
			this->button4->Margin = System::Windows::Forms::Padding(0);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(101, 80);
			this->button4->TabIndex = 4;
			this->button4->Text = L"4";
			this->button4->UseVisualStyleBackColor = false;
			this->button4->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// button5
			// 
			this->button5->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button5->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button5->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->button5->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button5->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button5->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button5->Location = System::Drawing::Point(101, 80);
			this->button5->Margin = System::Windows::Forms::Padding(0);
			this->button5->Name = L"button5";
			this->button5->Size = System::Drawing::Size(101, 80);
			this->button5->TabIndex = 5;
			this->button5->Text = L"5";
			this->button5->UseVisualStyleBackColor = false;
			this->button5->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// button6
			// 
			this->button6->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button6->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button6->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->button6->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button6->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button6->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button6->Location = System::Drawing::Point(202, 80);
			this->button6->Margin = System::Windows::Forms::Padding(0);
			this->button6->Name = L"button6";
			this->button6->Size = System::Drawing::Size(101, 80);
			this->button6->TabIndex = 6;
			this->button6->Text = L"6";
			this->button6->UseVisualStyleBackColor = false;
			this->button6->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// button7
			// 
			this->button7->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button7->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button7->BackColor = System::Drawing::Color::White;
			this->button7->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button7->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button7->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button7->Location = System::Drawing::Point(0, 0);
			this->button7->Margin = System::Windows::Forms::Padding(0);
			this->button7->Name = L"button7";
			this->button7->Size = System::Drawing::Size(101, 80);
			this->button7->TabIndex = 7;
			this->button7->Text = L"7";
			this->button7->UseVisualStyleBackColor = false;
			this->button7->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// button8
			// 
			this->button8->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button8->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button8->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->button8->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button8->FlatAppearance->MouseDownBackColor = System::Drawing::SystemColors::ControlLight;
			this->button8->FlatAppearance->MouseOverBackColor = System::Drawing::SystemColors::ControlLight;
			this->button8->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button8->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button8->Location = System::Drawing::Point(101, 0);
			this->button8->Margin = System::Windows::Forms::Padding(0);
			this->button8->Name = L"button8";
			this->button8->Size = System::Drawing::Size(101, 80);
			this->button8->TabIndex = 8;
			this->button8->Text = L"8";
			this->button8->UseVisualStyleBackColor = false;
			this->button8->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// button9
			// 
			this->button9->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button9->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button9->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->button9->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button9->FlatAppearance->MouseDownBackColor = System::Drawing::SystemColors::ControlLight;
			this->button9->FlatAppearance->MouseOverBackColor = System::Drawing::SystemColors::ControlLight;
			this->button9->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button9->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button9->Location = System::Drawing::Point(202, 0);
			this->button9->Margin = System::Windows::Forms::Padding(0);
			this->button9->Name = L"button9";
			this->button9->Size = System::Drawing::Size(101, 80);
			this->button9->TabIndex = 9;
			this->button9->Text = L"9";
			this->button9->UseVisualStyleBackColor = false;
			this->button9->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// BTN_add
			// 
			this->BTN_add->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->BTN_add->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->BTN_add->BackColor = System::Drawing::SystemColors::Menu;
			this->BTN_add->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->BTN_add->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->BTN_add->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 19.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->BTN_add->Location = System::Drawing::Point(303, 0);
			this->BTN_add->Margin = System::Windows::Forms::Padding(0);
			this->BTN_add->Name = L"BTN_add";
			this->BTN_add->Size = System::Drawing::Size(102, 80);
			this->BTN_add->TabIndex = 10;
			this->BTN_add->Text = L"+";
			this->BTN_add->UseVisualStyleBackColor = false;
			this->BTN_add->Click += gcnew System::EventHandler(this, &MyForm::BTN_add_Click);
			// 
			// BTN_minus
			// 
			this->BTN_minus->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->BTN_minus->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->BTN_minus->BackColor = System::Drawing::SystemColors::Menu;
			this->BTN_minus->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->BTN_minus->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->BTN_minus->Font = (gcnew System::Drawing::Font(L"Segoe UI", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->BTN_minus->Location = System::Drawing::Point(303, 80);
			this->BTN_minus->Margin = System::Windows::Forms::Padding(0);
			this->BTN_minus->Name = L"BTN_minus";
			this->BTN_minus->Padding = System::Windows::Forms::Padding(0, 0, 5, 0);
			this->BTN_minus->Size = System::Drawing::Size(102, 80);
			this->BTN_minus->TabIndex = 11;
			this->BTN_minus->Text = L" —";
			this->BTN_minus->UseVisualStyleBackColor = false;
			this->BTN_minus->Click += gcnew System::EventHandler(this, &MyForm::BTN_minus_Click);
			// 
			// BTN_to_hour
			// 
			this->BTN_to_hour->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->BTN_to_hour->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->BTN_to_hour->BackColor = System::Drawing::Color::Transparent;
			this->BTN_to_hour->FlatAppearance->BorderColor = System::Drawing::Color::Gainsboro;
			this->BTN_to_hour->FlatAppearance->BorderSize = 2;
			this->BTN_to_hour->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->BTN_to_hour->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->BTN_to_hour->Location = System::Drawing::Point(0, 0);
			this->BTN_to_hour->Margin = System::Windows::Forms::Padding(0);
			this->BTN_to_hour->Name = L"BTN_to_hour";
			this->BTN_to_hour->Size = System::Drawing::Size(135, 80);
			this->BTN_to_hour->TabIndex = 12;
			this->BTN_to_hour->Text = L"В часы";
			this->BTN_to_hour->UseVisualStyleBackColor = false;
			this->BTN_to_hour->Click += gcnew System::EventHandler(this, &MyForm::BTN_to_hour_Click);
			// 
			// BTN_to_min
			// 
			this->BTN_to_min->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->BTN_to_min->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->BTN_to_min->BackColor = System::Drawing::Color::Transparent;
			this->BTN_to_min->FlatAppearance->BorderColor = System::Drawing::Color::Gainsboro;
			this->BTN_to_min->FlatAppearance->BorderSize = 2;
			this->BTN_to_min->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->BTN_to_min->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->BTN_to_min->Location = System::Drawing::Point(135, 0);
			this->BTN_to_min->Margin = System::Windows::Forms::Padding(0);
			this->BTN_to_min->Name = L"BTN_to_min";
			this->BTN_to_min->Size = System::Drawing::Size(135, 80);
			this->BTN_to_min->TabIndex = 13;
			this->BTN_to_min->Text = L"В минуты";
			this->BTN_to_min->UseVisualStyleBackColor = false;
			this->BTN_to_min->Click += gcnew System::EventHandler(this, &MyForm::BTN_to_min_Click);
			// 
			// BTN_point
			// 
			this->BTN_point->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->BTN_point->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->BTN_point->BackColor = System::Drawing::SystemColors::Menu;
			this->BTN_point->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->BTN_point->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->BTN_point->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 19.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->BTN_point->Location = System::Drawing::Point(0, 240);
			this->BTN_point->Margin = System::Windows::Forms::Padding(0);
			this->BTN_point->Name = L"BTN_point";
			this->BTN_point->Size = System::Drawing::Size(101, 82);
			this->BTN_point->TabIndex = 16;
			this->BTN_point->Text = L"::";
			this->BTN_point->UseVisualStyleBackColor = false;
			this->BTN_point->Click += gcnew System::EventHandler(this, &MyForm::BTN_point_Click);
			// 
			// button0
			// 
			this->button0->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->button0->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->button0->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->button0->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->button0->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button0->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 18, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->button0->ForeColor = System::Drawing::Color::Black;
			this->button0->Location = System::Drawing::Point(101, 240);
			this->button0->Margin = System::Windows::Forms::Padding(0);
			this->button0->Name = L"button0";
			this->button0->Size = System::Drawing::Size(101, 82);
			this->button0->TabIndex = 15;
			this->button0->Text = L"0";
			this->button0->UseVisualStyleBackColor = false;
			this->button0->Click += gcnew System::EventHandler(this, &MyForm::InsertDigit);
			// 
			// BTN_clear
			// 
			this->BTN_clear->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->BTN_clear->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->BTN_clear->BackColor = System::Drawing::SystemColors::Menu;
			this->BTN_clear->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->BTN_clear->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->BTN_clear->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 19.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->BTN_clear->ForeColor = System::Drawing::Color::Black;
			this->BTN_clear->Location = System::Drawing::Point(202, 240);
			this->BTN_clear->Margin = System::Windows::Forms::Padding(0);
			this->BTN_clear->Name = L"BTN_clear";
			this->BTN_clear->Size = System::Drawing::Size(101, 82);
			this->BTN_clear->TabIndex = 34;
			this->BTN_clear->Text = L"C";
			this->BTN_clear->UseVisualStyleBackColor = false;
			this->BTN_clear->Click += gcnew System::EventHandler(this, &MyForm::BTN_clear_Click);
			// 
			// TXT_main_m
			// 
			this->TXT_main_m->BackColor = System::Drawing::Color::Gainsboro;
			this->TXT_main_m->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->TXT_main_m->Dock = System::Windows::Forms::DockStyle::Top;
			this->TXT_main_m->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 25.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->TXT_main_m->Location = System::Drawing::Point(0, 0);
			this->TXT_main_m->Margin = System::Windows::Forms::Padding(0);
			this->TXT_main_m->MaxLength = 12;
			this->TXT_main_m->Name = L"TXT_main_m";
			this->TXT_main_m->RightToLeft = System::Windows::Forms::RightToLeft::Yes;
			this->TXT_main_m->Size = System::Drawing::Size(379, 58);
			this->TXT_main_m->TabIndex = 15;
			this->TXT_main_m->TextChanged += gcnew System::EventHandler(this, &MyForm::TXT_main_m_TextChanged);
			// 
			// TXT_main_s
			// 
			this->TXT_main_s->BackColor = System::Drawing::Color::Gainsboro;
			this->TXT_main_s->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->TXT_main_s->Dock = System::Windows::Forms::DockStyle::Top;
			this->TXT_main_s->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 25.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->TXT_main_s->Location = System::Drawing::Point(0, 0);
			this->TXT_main_s->Margin = System::Windows::Forms::Padding(0);
			this->TXT_main_s->MaxLength = 14;
			this->TXT_main_s->Name = L"TXT_main_s";
			this->TXT_main_s->RightToLeft = System::Windows::Forms::RightToLeft::Yes;
			this->TXT_main_s->Size = System::Drawing::Size(379, 58);
			this->TXT_main_s->TabIndex = 16;
			this->TXT_main_s->TextChanged += gcnew System::EventHandler(this, &MyForm::TXT_main_s_TextChanged);
			// 
			// BTN_to_sec
			// 
			this->BTN_to_sec->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->BTN_to_sec->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->BTN_to_sec->BackColor = System::Drawing::Color::Transparent;
			this->BTN_to_sec->FlatAppearance->BorderColor = System::Drawing::Color::Gainsboro;
			this->BTN_to_sec->FlatAppearance->BorderSize = 2;
			this->BTN_to_sec->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->BTN_to_sec->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->BTN_to_sec->Location = System::Drawing::Point(270, 0);
			this->BTN_to_sec->Margin = System::Windows::Forms::Padding(0);
			this->BTN_to_sec->Name = L"BTN_to_sec";
			this->BTN_to_sec->Size = System::Drawing::Size(135, 80);
			this->BTN_to_sec->TabIndex = 33;
			this->BTN_to_sec->Text = L"В секунды";
			this->BTN_to_sec->UseVisualStyleBackColor = false;
			this->BTN_to_sec->Click += gcnew System::EventHandler(this, &MyForm::BTN_to_sec_Click);
			// 
			// BTN_equals
			// 
			this->BTN_equals->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->BTN_equals->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->BTN_equals->BackColor = System::Drawing::SystemColors::Menu;
			this->BTN_equals->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->BTN_equals->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->BTN_equals->Font = (gcnew System::Drawing::Font(L"Segoe UI Semibold", 19.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->BTN_equals->ForeColor = System::Drawing::Color::Black;
			this->BTN_equals->Location = System::Drawing::Point(303, 240);
			this->BTN_equals->Margin = System::Windows::Forms::Padding(0);
			this->BTN_equals->Name = L"BTN_equals";
			this->BTN_equals->RightToLeft = System::Windows::Forms::RightToLeft::No;
			this->BTN_equals->Size = System::Drawing::Size(102, 82);
			this->BTN_equals->TabIndex = 34;
			this->BTN_equals->Text = L"=";
			this->BTN_equals->UseVisualStyleBackColor = false;
			this->BTN_equals->Click += gcnew System::EventHandler(this, &MyForm::BTN_equals_Click);
			// 
			// BTN_delete_last
			// 
			this->BTN_delete_last->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->BTN_delete_last->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
			this->BTN_delete_last->BackColor = System::Drawing::SystemColors::Menu;
			this->BTN_delete_last->FlatAppearance->BorderColor = System::Drawing::Color::LightGray;
			this->BTN_delete_last->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->BTN_delete_last->Font = (gcnew System::Drawing::Font(L"Segoe UI", 19.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->BTN_delete_last->Location = System::Drawing::Point(303, 160);
			this->BTN_delete_last->Margin = System::Windows::Forms::Padding(0);
			this->BTN_delete_last->Name = L"BTN_delete_last";
			this->BTN_delete_last->Size = System::Drawing::Size(102, 80);
			this->BTN_delete_last->TabIndex = 35;
			this->BTN_delete_last->Text = L"←";
			this->BTN_delete_last->UseVisualStyleBackColor = false;
			this->BTN_delete_last->Click += gcnew System::EventHandler(this, &MyForm::BTN_empty_Click);
			// 
			// tableLayoutPanel1
			// 
			this->tableLayoutPanel1->ColumnCount = 3;
			this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				33.33333F)));
			this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				33.33333F)));
			this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				33.33333F)));
			this->tableLayoutPanel1->Controls->Add(this->BTN_to_hour, 0, 0);
			this->tableLayoutPanel1->Controls->Add(this->BTN_to_sec, 2, 0);
			this->tableLayoutPanel1->Controls->Add(this->BTN_to_min, 1, 0);
			this->tableLayoutPanel1->Location = System::Drawing::Point(1, 354);
			this->tableLayoutPanel1->Margin = System::Windows::Forms::Padding(0);
			this->tableLayoutPanel1->Name = L"tableLayoutPanel1";
			this->tableLayoutPanel1->RowCount = 1;
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 100)));
			this->tableLayoutPanel1->Size = System::Drawing::Size(405, 80);
			this->tableLayoutPanel1->TabIndex = 38;
			this->tableLayoutPanel1->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::tableLayoutPanel1_Paint);
			// 
			// tableLayoutPanel2
			// 
			this->tableLayoutPanel2->ColumnCount = 4;
			this->tableLayoutPanel2->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				25)));
			this->tableLayoutPanel2->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				25)));
			this->tableLayoutPanel2->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				25)));
			this->tableLayoutPanel2->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				25)));
			this->tableLayoutPanel2->Controls->Add(this->button7, 0, 0);
			this->tableLayoutPanel2->Controls->Add(this->BTN_point, 0, 3);
			this->tableLayoutPanel2->Controls->Add(this->button8, 1, 0);
			this->tableLayoutPanel2->Controls->Add(this->BTN_equals, 3, 3);
			this->tableLayoutPanel2->Controls->Add(this->button9, 2, 0);
			this->tableLayoutPanel2->Controls->Add(this->BTN_clear, 2, 3);
			this->tableLayoutPanel2->Controls->Add(this->BTN_add, 3, 0);
			this->tableLayoutPanel2->Controls->Add(this->button0, 1, 3);
			this->tableLayoutPanel2->Controls->Add(this->BTN_minus, 3, 1);
			this->tableLayoutPanel2->Controls->Add(this->button6, 2, 1);
			this->tableLayoutPanel2->Controls->Add(this->button5, 1, 1);
			this->tableLayoutPanel2->Controls->Add(this->button4, 0, 1);
			this->tableLayoutPanel2->Controls->Add(this->BTN_delete_last, 3, 2);
			this->tableLayoutPanel2->Controls->Add(this->button3, 2, 2);
			this->tableLayoutPanel2->Controls->Add(this->button2, 1, 2);
			this->tableLayoutPanel2->Controls->Add(this->button1, 0, 2);
			this->tableLayoutPanel2->Location = System::Drawing::Point(1, 434);
			this->tableLayoutPanel2->Margin = System::Windows::Forms::Padding(0);
			this->tableLayoutPanel2->Name = L"tableLayoutPanel2";
			this->tableLayoutPanel2->RowCount = 4;
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 25)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 25)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 25)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 25)));
			this->tableLayoutPanel2->Size = System::Drawing::Size(405, 322);
			this->tableLayoutPanel2->TabIndex = 39;
			// 
			// tableLayoutPanel3
			// 
			this->tableLayoutPanel3->BackColor = System::Drawing::Color::Gainsboro;
			this->tableLayoutPanel3->ColumnCount = 1;
			this->tableLayoutPanel3->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				78.47222F)));
			this->tableLayoutPanel3->Controls->Add(this->PNL_main_s, 0, 2);
			this->tableLayoutPanel3->Controls->Add(this->PNL_main_h, 0, 0);
			this->tableLayoutPanel3->Controls->Add(this->PNL_main_m, 0, 1);
			this->tableLayoutPanel3->Location = System::Drawing::Point(0, 38);
			this->tableLayoutPanel3->Margin = System::Windows::Forms::Padding(0);
			this->tableLayoutPanel3->Name = L"tableLayoutPanel3";
			this->tableLayoutPanel3->RowCount = 3;
			this->tableLayoutPanel3->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 33.33333F)));
			this->tableLayoutPanel3->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 33.33333F)));
			this->tableLayoutPanel3->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 33.33333F)));
			this->tableLayoutPanel3->Size = System::Drawing::Size(405, 316);
			this->tableLayoutPanel3->TabIndex = 40;
			this->tableLayoutPanel3->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::tableLayoutPanel3_Paint);
			// 
			// PNL_main_s
			// 
			this->PNL_main_s->Controls->Add(this->panel5);
			this->PNL_main_s->Controls->Add(this->TXT_main_s);
			this->PNL_main_s->Location = System::Drawing::Point(15, 220);
			this->PNL_main_s->Margin = System::Windows::Forms::Padding(15, 10, 11, 5);
			this->PNL_main_s->Name = L"PNL_main_s";
			this->PNL_main_s->Size = System::Drawing::Size(379, 86);
			this->PNL_main_s->TabIndex = 41;
			// 
			// panel5
			// 
			this->panel5->BackColor = System::Drawing::Color::Gainsboro;
			this->panel5->Controls->Add(this->LBL_main_s);
			this->panel5->Dock = System::Windows::Forms::DockStyle::Bottom;
			this->panel5->Location = System::Drawing::Point(0, 62);
			this->panel5->Margin = System::Windows::Forms::Padding(0);
			this->panel5->Name = L"panel5";
			this->panel5->Padding = System::Windows::Forms::Padding(0, 0, 3, 0);
			this->panel5->Size = System::Drawing::Size(379, 24);
			this->panel5->TabIndex = 47;
			// 
			// LBL_main_s
			// 
			this->LBL_main_s->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->LBL_main_s->BackColor = System::Drawing::Color::Gainsboro;
			this->LBL_main_s->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->LBL_main_s->Enabled = false;
			this->LBL_main_s->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->LBL_main_s->Location = System::Drawing::Point(274, 0);
			this->LBL_main_s->Margin = System::Windows::Forms::Padding(0);
			this->LBL_main_s->Name = L"LBL_main_s";
			this->LBL_main_s->ReadOnly = true;
			this->LBL_main_s->Size = System::Drawing::Size(100, 22);
			this->LBL_main_s->TabIndex = 47;
			this->LBL_main_s->Text = L"секунды";
			this->LBL_main_s->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
			this->LBL_main_s->TextChanged += gcnew System::EventHandler(this, &MyForm::textBox1_TextChanged);
			// 
			// PNL_main_h
			// 
			this->PNL_main_h->Controls->Add(this->panel3);
			this->PNL_main_h->Controls->Add(this->TXT_main_h);
			this->PNL_main_h->Location = System::Drawing::Point(15, 10);
			this->PNL_main_h->Margin = System::Windows::Forms::Padding(15, 10, 11, 5);
			this->PNL_main_h->Name = L"PNL_main_h";
			this->PNL_main_h->Size = System::Drawing::Size(379, 85);
			this->PNL_main_h->TabIndex = 41;
			this->PNL_main_h->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::PNL_main_h_Paint);
			// 
			// panel3
			// 
			this->panel3->BackColor = System::Drawing::Color::Gainsboro;
			this->panel3->Controls->Add(this->LBL_main_h);
			this->panel3->Dock = System::Windows::Forms::DockStyle::Bottom;
			this->panel3->Location = System::Drawing::Point(0, 63);
			this->panel3->Margin = System::Windows::Forms::Padding(0);
			this->panel3->Name = L"panel3";
			this->panel3->Padding = System::Windows::Forms::Padding(0, 0, 3, 0);
			this->panel3->Size = System::Drawing::Size(379, 22);
			this->panel3->TabIndex = 47;
			// 
			// LBL_main_h
			// 
			this->LBL_main_h->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->LBL_main_h->BackColor = System::Drawing::Color::Gainsboro;
			this->LBL_main_h->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->LBL_main_h->Enabled = false;
			this->LBL_main_h->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->LBL_main_h->Location = System::Drawing::Point(274, 0);
			this->LBL_main_h->Margin = System::Windows::Forms::Padding(0);
			this->LBL_main_h->Name = L"LBL_main_h";
			this->LBL_main_h->ReadOnly = true;
			this->LBL_main_h->Size = System::Drawing::Size(100, 22);
			this->LBL_main_h->TabIndex = 46;
			this->LBL_main_h->Text = L"часы";
			this->LBL_main_h->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
			this->LBL_main_h->TextChanged += gcnew System::EventHandler(this, &MyForm::LBL_main_h_TextChanged);
			// 
			// PNL_main_m
			// 
			this->PNL_main_m->Controls->Add(this->panel4);
			this->PNL_main_m->Controls->Add(this->TXT_main_m);
			this->PNL_main_m->Location = System::Drawing::Point(15, 115);
			this->PNL_main_m->Margin = System::Windows::Forms::Padding(15, 10, 11, 5);
			this->PNL_main_m->Name = L"PNL_main_m";
			this->PNL_main_m->Size = System::Drawing::Size(379, 85);
			this->PNL_main_m->TabIndex = 41;
			// 
			// panel4
			// 
			this->panel4->BackColor = System::Drawing::Color::Gainsboro;
			this->panel4->Controls->Add(this->LBL_main_m);
			this->panel4->Dock = System::Windows::Forms::DockStyle::Bottom;
			this->panel4->Location = System::Drawing::Point(0, 63);
			this->panel4->Margin = System::Windows::Forms::Padding(0);
			this->panel4->Name = L"panel4";
			this->panel4->Padding = System::Windows::Forms::Padding(0, 0, 3, 0);
			this->panel4->Size = System::Drawing::Size(379, 22);
			this->panel4->TabIndex = 47;
			// 
			// LBL_main_m
			// 
			this->LBL_main_m->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->LBL_main_m->BackColor = System::Drawing::Color::Gainsboro;
			this->LBL_main_m->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->LBL_main_m->Enabled = false;
			this->LBL_main_m->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9.75F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->LBL_main_m->Location = System::Drawing::Point(274, 0);
			this->LBL_main_m->Margin = System::Windows::Forms::Padding(0);
			this->LBL_main_m->Name = L"LBL_main_m";
			this->LBL_main_m->ReadOnly = true;
			this->LBL_main_m->Size = System::Drawing::Size(100, 22);
			this->LBL_main_m->TabIndex = 47;
			this->LBL_main_m->Text = L"минуты";
			this->LBL_main_m->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
			// 
			// LOG
			// 
			this->LOG->BackColor = System::Drawing::Color::Gainsboro;
			this->LOG->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->LOG->Font = (gcnew System::Drawing::Font(L"Courier New", 10.8F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->LOG->Location = System::Drawing::Point(412, 38);
			this->LOG->Multiline = true;
			this->LOG->Name = L"LOG";
			this->LOG->ReadOnly = true;
			this->LOG->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
			this->LOG->Size = System::Drawing::Size(425, 718);
			this->LOG->TabIndex = 41;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 17);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::Gainsboro;
			this->ClientSize = System::Drawing::Size(837, 758);
			this->Controls->Add(this->LOG);
			this->Controls->Add(this->tableLayoutPanel3);
			this->Controls->Add(this->tableLayoutPanel2);
			this->Controls->Add(this->tableLayoutPanel1);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->MaximizeBox = false;
			this->Name = L"MyForm";
			this->ShowIcon = false;
			this->Text = L"Time Calculator";
			this->TransparencyKey = System::Drawing::Color::Red;
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->tableLayoutPanel1->ResumeLayout(false);
			this->tableLayoutPanel2->ResumeLayout(false);
			this->tableLayoutPanel3->ResumeLayout(false);
			this->PNL_main_s->ResumeLayout(false);
			this->PNL_main_s->PerformLayout();
			this->panel5->ResumeLayout(false);
			this->panel5->PerformLayout();
			this->PNL_main_h->ResumeLayout(false);
			this->PNL_main_h->PerformLayout();
			this->panel3->ResumeLayout(false);
			this->panel3->PerformLayout();
			this->PNL_main_m->ResumeLayout(false);
			this->PNL_main_m->PerformLayout();
			this->panel4->ResumeLayout(false);
			this->panel4->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
		
//----------------------------------МОИ ПОЛЯ ---------------------------------

	private:
	
		clsTime^ first; clsTime^ second; clsTime^ third; clsTime^ temp;
		int SECTION = 0;	// 0 - ПОЛЕ "ЧАСЫ", 1 - ПОЛЕ "МИНУТЫ", 2 - ПОЛЕ "СЕКУНДЫ"
		int FUNCTION = 0;	//1 - СЛОЖЕНИЕ, 2 - ВЫЧИТАНИЕ

//--------------------------------- МОИ ФУНКЦИИ --------------------------------

// ОБРАБОТКА СОБЫТИЙ

		// ФУНКЦИИ ОБРАБОТКИ СОБЫТИЙ КНОПОК

		// ВСТАВКА ЗНАЧЕНИЯ ТЕКСТА ПЕРЕДАННОЙ КНОПКИ В ТЕКУЩЕЕ ПОЛЕ
		System::Void InsertDigit(System::Object^ sender, System::EventArgs^ e) {
			System::Windows::Forms::Button^ b = (Button^)sender;
			switch (SECTION) {
			case 0: if (TXT_main_h->Text->Length == 10) LOG->AppendText("\r\nПоле переполнено\r\n");
				  else { TXT_main_h->Text += b->Text; Set_active(TXT_main_h); }
				  break;
			case 1: if (TXT_main_m->Text->Length == 12) LOG->AppendText("\r\nПоле переполнено\r\n");
				  else { TXT_main_m->Text += b->Text; Set_active(TXT_main_m); }
				  break;
			case 2: if (TXT_main_s->Text->Length == 14) LOG->AppendText("\r\nПоле переполнено\r\n");
				  else { TXT_main_s->Text += b->Text; Set_active(TXT_main_s); }
				  break;
			default:if (TXT_main_h->Text->Length == 10) LOG->AppendText("\r\nПоле переполнено\r\n");
				   else { TXT_main_h->Text += b->Text; Set_active(TXT_main_h); }
				   break;
			}
		}

		// ПЕРЕВОД КАРЕТКИ
		System::Void BTN_point_Click(System::Object^ sender, System::EventArgs^ e) {
			switch (SECTION) {
			case 0: SECTION = 1; Set_active(TXT_main_m); break;
			case 1: SECTION = 2; Set_active(TXT_main_s); break;
			case 2: SECTION = 0; Set_active(TXT_main_h); break;
			default: SECTION = 0; Set_active(TXT_main_h); break;
			}
			PanelColor();
		}

		// УДАЛЕНИЕ ПОСЛЕДНЕГО ЭЛЕМЕНТА ИЗ ПОЛЯ
		System::Void BTN_empty_Click(System::Object^ sender, System::EventArgs^ e) {
			System::String^ s;
			switch (SECTION) {
			case 0: s = TXT_main_h->Text; s->Length > 1 ? s = s->Substring(0, s->Length - 1) : s = ""; TXT_main_h->Text = s; Set_active(TXT_main_h); break;
			case 1: s = TXT_main_m->Text; s->Length > 1 ? s = s->Substring(0, s->Length - 1) : s = ""; TXT_main_m->Text = s; Set_active(TXT_main_m); break;
			case 2: s = TXT_main_s->Text; s->Length > 1 ? s = s->Substring(0, s->Length - 1) : s = ""; TXT_main_s->Text = s; Set_active(TXT_main_s); break;
			}
		}

		// ОЧИСТКА ПОЛЕЙ И ПЕРЕМЕННЫХ
		System::Void BTN_clear_Click(System::Object^ sender, System::EventArgs^ e) {
			FUNCTION = 0;
			LOG->AppendText("\r\nСброс\r\n");
			ClearAllFields();
			ResetTime();
			switch (SECTION) {
			case 0: Set_active(TXT_main_h); break;
			case 1: Set_active(TXT_main_m); break;
			case 2: Set_active(TXT_main_s); break;
			default: Set_active(TXT_main_h); break;
			}
		}

		// СЛОЖЕНИЕ
		System::Void BTN_add_Click(System::Object^ sender, System::EventArgs^ e) {
			if (FieldNotEmpty()) {
				if (FUNCTION != 1) {
					GetFields(first);

					FUNCTION = 1;
					LOG->AppendText("\r\n\r\n");
					LOG->AppendText(first->hours + " " + LBL_main_h->Text + " " + first->minutes + " " + LBL_main_m->Text + " " + first->seconds + " " + LBL_main_s->Text);
					LOG->AppendText("\r\n+\r\n");
					ClearAllFields();
					Set_active(TXT_main_h);
					SECTION = 0;
					PanelColor();
				}
				//else LOG->AppendText("\r\n Операция сложения уже выбрана \r\n");
			}
			Set_active(TXT_main_h);
		}

		// ВЫЧИТАНИЕ
		System::Void BTN_minus_Click(System::Object^ sender, System::EventArgs^ e) {
			if (FieldNotEmpty()) {
				if (FUNCTION != 2) {
					GetFields(first);

					FUNCTION = 2;
					LOG->AppendText("\r\n\r\n");
					LOG->AppendText(first->hours + " " + LBL_main_h->Text + " " + first->minutes + " " + LBL_main_m->Text + " " + first->seconds + " " + LBL_main_s->Text);
					LOG->AppendText("\r\n-\r\n");
					ClearAllFields();
					Set_active(TXT_main_h);
					SECTION = 0;
					PanelColor();
				}
				//else LOG->AppendText("\r\n Операция вычитания уже выбрана \r\n");
			}
			Set_active(TXT_main_h);
			//else LOG->AppendText("\r\nПустые поля!\r\n");
		}

		// ВЫЧИСЛЕНИЕ РЕЗУЛЬТАТА ТЕКУЩЕЙ ФУНКЦИИ
		System::Void BTN_equals_Click(System::Object^ sender, System::EventArgs^ e) {
			GetFields(second);
			switch (FUNCTION) {
			case 0: return;
			case 1: third = first + second; break;
			case 2: third = first - second; break;
			case 3:
			default: break;
			}
			ClearAllFields();
			Equals_Display(third);
			LOG->AppendText(second->hours + " " + LBL_main_h->Text + " " + second->minutes + " " + LBL_main_m->Text + " " + second->seconds + " " + LBL_main_s->Text);
			LOG->AppendText("\r\n------------------------------------\r\n");
			LOG->AppendText(third->hours + " " + LBL_main_h->Text + " " + third->minutes + " " + LBL_main_m->Text + " " + third->seconds + " " + LBL_main_s->Text);
			LOG->AppendText("\r\n\r\n");
			FUNCTION = 0;
			PanelColor();
		}

		// ПЕРЕВОД В ЧАСЫ
		System::Void BTN_to_hour_Click(System::Object^ sender, System::EventArgs^ e) {
			if (FieldNotEmpty()) {
				LOG->AppendText("\r\n\r\nКовертирование в часы.\r\n");
				GetFields(first);
				LOG->AppendText(first->hours + " " + LBL_main_h->Text + " " + first->minutes + " " + LBL_main_m->Text + " " + first->seconds + " " + LBL_main_s->Text);
				LOG->AppendText("\r\nв часах:\r\n");
				ClearAllFields();
				first->ConvertToHours();
				Display(first);
				LOG->AppendText(first->hours + " " + LBL_main_h->Text + " " + first->minutes + " " + LBL_main_m->Text + " " + first->seconds + " " + LBL_main_s->Text);
				PanelColor();
				//Set_active(TXT_main_h);
			}
			//else LOG->AppendText("\r\nПустые поля!\r\n");
		}

		// ПЕРЕВОД В МИНУТЫ
		System::Void BTN_to_min_Click(System::Object^ sender, System::EventArgs^ e) {
			if (FieldNotEmpty()) {
				LOG->AppendText("\r\n\r\nКовертирование в минуты.\r\n");
				GetFields(first);
				LOG->AppendText(first->hours + " " + LBL_main_h->Text + " " + first->minutes + " " + LBL_main_m->Text + " " + first->seconds + " " + LBL_main_s->Text);
				LOG->AppendText("\r\nв минутах:\r\n");
				ClearAllFields();
				first->ConvertToMin();
				Display(first);
				LOG->AppendText(first->hours + " " + LBL_main_h->Text + " " + first->minutes + " " + LBL_main_m->Text + " " + first->seconds + " " + LBL_main_s->Text);
				PanelColor();
				//Set_active(TXT_main_m);
			}
			//else LOG->AppendText("\r\nПустые поля!\r\n");
		}

		// ПЕРЕВОД В СЕКУНДЫ
		System::Void BTN_to_sec_Click(System::Object^ sender, System::EventArgs^ e) {
			if (FieldNotEmpty()) {
				LOG->AppendText("\r\n\r\nКовертирование в секунды.\r\n");
				GetFields(first);
				LOG->AppendText(first->hours + " " + LBL_main_h->Text + " " + first->minutes + " " + LBL_main_m->Text + " " + first->seconds + " " + LBL_main_s->Text);
				LOG->AppendText("\r\nв секундах:\r\n");
				ClearAllFields();
				first->ConvertToSec();
				Display(first);
				LOG->AppendText(first->hours + " " + LBL_main_h->Text + " " + first->minutes + " " + LBL_main_m->Text + " " + first->seconds + " " + LBL_main_s->Text);
				PanelColor();
				//Set_active(TXT_main_s);
			}
			//else LOG->AppendText("\r\nПустые поля!\r\n");
		}

		// ФУНКЦИИ ОБРАБОТКИ СОБЫТИЙ ПОЛЕЙ

		// ОБРАБОТКА ИЗМЕНИЯ ПОЛЯ "ЧАСЫ"
		System::Void TXT_main_h_TextChanged(System::Object^ sender, System::EventArgs^ e) {
			GetFields(temp);
			TimeSpelling(temp);
		}

		// ОБРАБОТКА ИЗМЕНИЯ ПОЛЯ "МИНУТЫ"
		System::Void TXT_main_m_TextChanged(System::Object^ sender, System::EventArgs^ e) {
			GetFields(temp);
			TimeSpelling(temp);
		}

		// ОБРАБОТКА ИЗМЕНИЯ ПОЛЯ "СЕКУНДЫ"
		System::Void TXT_main_s_TextChanged(System::Object^ sender, System::EventArgs^ e) {
			GetFields(temp);
			TimeSpelling(temp);
		}

		// ОБРАБОТКА ПОЛУЧЕНИЯ ФОКУСА НА ПОЛЕ
		System::Void TXT_got_focus(System::Object^ sender, System::EventArgs^ e) {

			System::Windows::Forms::TextBox^ t = (TextBox^)sender;
			System::String^ s = t->Name;
			int x = s->Length;
			wchar_t c = s[x - 1];
			if (t->Name == "TXT_main_h") {
				SECTION = 0;
				ActiveControl = TXT_main_h;
			}
			if (t->Name == "TXT_main_m") {
				SECTION = 1;
				ActiveControl = TXT_main_m;
			}
			if (t->Name == "TXT_main_s") {
				SECTION = 2;
				ActiveControl = TXT_main_s;
			}
			PanelColor();
		}

// ПРОЧИЕ ФУНКЦИИ

		// ОЧИСТКА ВСЕХ ПОЛЕЙ
		System::Void ClearAllFields() {
			TXT_main_h->Clear();
			TXT_main_m->Clear();
			TXT_main_s->Clear();
		}

		// ПЕРЕВОД ФОКУСА НА ПЕРЕДАННОЕ ПОЛЕ
		System::Void Set_active(System::Windows::Forms::TextBox^ TXT) {
			ActiveControl = TXT;
			TXT->SelectionStart = TXT->Text->Length;
			TXT->SelectionLength = 0;
		}

		// ПРАВОПИСАНИЕ ТЕКУЩЕГО ЗНАЧЕНИЯ ВРЕМЕНИ
		System::Void TimeSpelling(clsTime^ t) {
			long long int h, m, s;
			h = t->hours; m = t->minutes; s = t->seconds;
			while (h > 10) {
				h %= 10;
			}
			if (h == 1) LBL_main_h->Text = "час";
			else if (h >= 2 && h <= 4) LBL_main_h->Text = "часа";
			else LBL_main_h->Text = "часов";

			while (m > 10) {
				m %= 10;
			}
			if (m == 1) LBL_main_m->Text = "минута";
			else if (m >= 2 && m <= 4) LBL_main_m->Text = "минуты";
			else LBL_main_m->Text = "минут";

			while (s > 10) {
				s %= 10;
			}
			if (s == 1) LBL_main_s->Text = "секунда";
			else if (s >= 2 && s <= 4) LBL_main_s->Text = "секунды";
			else LBL_main_s->Text = "секунд";
		}

		// ВЫВОД ЗНАЧЕНИЙ В ПОЛЯ
		System::Void Display(clsTime^ t) {
			if (t->hours != 0) {
				TXT_main_h->Text = t->hours.ToString();
				//ActiveControl = TXT_main_h;
				Set_active(TXT_main_h);
				SECTION = 0;
			}
			if (t->minutes != 0) {
				TXT_main_m->Text = t->minutes.ToString();
				if (t->hours == 0) {
					Set_active(TXT_main_m);
					//ActiveControl = TXT_main_m;
					SECTION = 1;
				}
			}
			if (t->seconds != 0) {
				TXT_main_s->Text = t->seconds.ToString();
				if (t->hours == 0 && t->minutes == 0) {
					Set_active(TXT_main_s);
					//ActiveControl = TXT_main_s;
					SECTION = 2;
				}
			}
			TimeSpelling(t);
		}

		// ВЫВОД ЗНАЧЕНИЙ (С НУЛЯМИ) В ПОЛЯ 
		System::Void Equals_Display(clsTime^ t) {
			//if (t->hours != 0) {
			TXT_main_h->Text = t->hours.ToString();
			Set_active(TXT_main_h);
			SECTION = 0;
			//}
			//if (t->minutes != 0) {
			TXT_main_m->Text = t->minutes.ToString();
			if (t->hours == 0) {
				Set_active(TXT_main_m);
				SECTION = 1;
			}
			//}
			//if (t->seconds != 0) {
			TXT_main_s->Text = t->seconds.ToString();
			if (t->hours == 0 && t->minutes == 0) {
				Set_active(TXT_main_s);
				SECTION = 2;
			}
			//}
			TimeSpelling(t);
		}

		// ПОЛУЧЕНИЯ ТЕКСТА ИЗ ПОЛЕЙ
		System::Void GetFields(clsTime^ t) {
			long long int a, b, c;
			try
			{
				a = Int64::Parse(TXT_main_h->Text);
			}
			catch (System::FormatException^ e) {
				a = 0;
			}
			try
			{
				b = Int64::Parse(TXT_main_m->Text);
			}
			catch (System::FormatException^ e) {
				b = 0;
			}
			try
			{
				c = Int64::Parse(TXT_main_s->Text);
			}
			catch (System::FormatException^ e) {
				c = 0;
			}
			t->hours = a;
			t->minutes = b;
			t->seconds = c;
		}

		// ОКРАШИВАНИЕ ПАНЕЛЕЙ (ДЛЯ ПОДСВЕТКИ ТЕКУЩЕГО ПОЛЯ)
		System::Void PanelColor() {
			Color Gray = Color::FromName("Gray");
			Color Gainsboro = Color::FromName("Gainsboro");
			switch (SECTION) {
			case 0: PNL_main_h->BackColor = Gray; PNL_main_m->BackColor = Gainsboro; PNL_main_s->BackColor = Gainsboro; break;
			case 1: PNL_main_m->BackColor = Gray; PNL_main_h->BackColor = Gainsboro; PNL_main_s->BackColor = Gainsboro; break;
			case 2: PNL_main_s->BackColor = Gray; PNL_main_h->BackColor = Gainsboro; PNL_main_m->BackColor = Gainsboro; break;
			}
		}

		// ПРИВЯЗКА СОБЫТИЙ ИЗМЕНЕНИЯ ФОКУСА ПОЛЕЙ С ОБРАБОТЧИКАМИ 
		System::Void InitTXTfocus() {
			this->TXT_main_h->GotFocus += gcnew System::EventHandler(this, &MyForm::TXT_got_focus);
			this->TXT_main_h->LostFocus += gcnew System::EventHandler(this, &MyForm::TXT_lost_focus);
			this->TXT_main_m->GotFocus += gcnew System::EventHandler(this, &MyForm::TXT_got_focus);
			this->TXT_main_m->LostFocus += gcnew System::EventHandler(this, &MyForm::TXT_lost_focus);
			this->TXT_main_s->GotFocus += gcnew System::EventHandler(this, &MyForm::TXT_got_focus);
			this->TXT_main_s->LostFocus += gcnew System::EventHandler(this, &MyForm::TXT_lost_focus);
		}

		// СОЗДАНИЕ ОБЪЕКТОВ ХРАНЕНИЯ ДАННЫХ ВРЕМЕНИ
		System::Void InitTime() {
			first = gcnew clsTime;
			second = gcnew clsTime;
			third = gcnew clsTime;
			temp = gcnew clsTime;
		}

		// СБРОС ПОЛЕЙ ОБЪЕКТОВ ХРАНЕНИЯ ДАННЫХ ВРЕМЕНИ
		System::Void ResetTime() {
			first->reset();
			second->reset();
			third->reset();
			temp->reset();
		}

		// ПРОВЕРКА ВСЕХ ПОЛЕЙ НА НАЛИЧИЕ В НИХ ДАННЫХ
		bool FieldNotEmpty() {
			bool h, m, s;
			h = System::String::IsNullOrWhiteSpace(TXT_main_h->Text);
			m = System::String::IsNullOrWhiteSpace(TXT_main_m->Text);
			s = System::String::IsNullOrWhiteSpace(TXT_main_s->Text);
			if (h && m && s) { LOG->AppendText("\r\nВсе поля пустые\r\n"); return false; }
			else return true;
		}

// НЕИСПОЛЬЗУЕМЫЕ / ПУСТЫЕ ФУНКЦИИ

	System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void tableLayoutPanel1_Paint(System::Object^ sender, System::Windows::Forms::PaintEventArgs^ e) {
	}
	private: System::Void LBL_main_s_Click(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void LBL_main_h_Click(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void LBL_main_m_Click(System::Object^ sender, System::EventArgs^ e) {
	}
	System::Void LBL_main_Click(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void tableLayoutPanel3_Paint(System::Object^ sender, System::Windows::Forms::PaintEventArgs^ e) {
	}
	private: System::Void LBL_main_h_TextChanged(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void textBox1_TextChanged(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void PNL_main_h_Paint(System::Object^ sender, System::Windows::Forms::PaintEventArgs^ e) {
	}
	System::Void TXT_lost_focus(System::Object^ sender, System::EventArgs^ e) {
		/*
		System::Windows::Forms::TextBox^ t = (TextBox^)sender;
		System::String^ s = t->Name;
		int x = s->Length;
		wchar_t c = s[x - 1];
		if (t->Name == "TXT_main_h") {
			PNL_main_h->BackColor = White;
		}
		if (t->Name == "TXT_main_m") {
			PNL_main_m->BackColor = White;
		}
		if (t->Name == "TXT_main_s") {
			PNL_main_s->BackColor = White;
		}*/
	}
	};
}
