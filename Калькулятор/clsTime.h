#pragma once
#include "math.h"

ref class clsTime
{
	public:
		long long int hours, minutes, seconds;
	public:

		// ÊÎÍÑÒÐÓÊÒÎÐ ÏÎ ÓÌÎË×ÀÍÈÞ
		clsTime() {
			hours = 0;
			minutes = 0;
			seconds = 0;
		}

		// ÊÎÍÑÒÐÓÊÒÎÐ ÊÎÏÈÐÎÂÀÍÈß
		clsTime(const clsTime^& t) {
			hours = t->hours;
			minutes = t->minutes;
			seconds = t->seconds;
		}

		// ÑÁÐÎÑ ÂÑÅÕ ÏÎËÅÉ
		void reset() {
			hours = 0;
			minutes = 0;
			seconds = 0;
		}

		// ÏÅÐÅÂÎÄ Â ÑÅÊÓÍÄÛ
		void ConvertToSec() {
			seconds = hours * 3600 + minutes * 60 + seconds;
			hours = 0;
			minutes = 0;
		}

		// ÏÅÐÅÂÎÄ Â ÌÈÍÓÒÛ
		void ConvertToMin() {
			ConvertToSec();
			minutes = seconds / 60;
			seconds %= 60;
		}

		//ÏÅÐÅÂÎÄ Â ×ÀÑÛ
		void ConvertToHours() {
			ConvertToMin();
			hours = minutes / 60;
			minutes %= 60;
		}

		// ÏÅÐÅÃÐÓÇÊÀ ÎÏÅÐÀÒÎÐÎÂ
		clsTime^ operator+ (const clsTime^ t) {
			clsTime^ temp = gcnew clsTime;
			temp->hours = this->hours + t->hours;
			temp->minutes = this->minutes + t->minutes;
			temp->seconds = this->seconds + t->seconds;

			temp->minutes += temp->seconds / 60;
			temp->hours += temp->minutes / 60;
			temp->seconds = temp->seconds % 60;
			temp->minutes = temp->minutes % 60;
			return temp;
		}

		clsTime^ operator- (const clsTime^ t) {
			clsTime^ temp = gcnew clsTime;
			long long int sec1, sec2;
			sec1 = t->hours * 3600 + t->minutes * 60 + t->seconds;
			sec2 = this->hours * 3600 + this->minutes * 60 + this->seconds;
			sec1 = abs(sec1 - sec2);

			temp->hours = sec1 / 3600;
			sec1 %= 3600;
			temp->minutes = sec1 / 60;
			sec1 %= 60;
			temp->seconds = sec1;
			return temp;
		}

		clsTime^% operator= (const clsTime% t) {
			hours = t.hours;
			minutes = t.minutes;
			seconds = t.seconds;
			return this;
		}
};

