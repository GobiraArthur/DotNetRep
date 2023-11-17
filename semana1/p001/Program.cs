/*Problema 2 : Quais são os tipos de dados numéricos inteiros disponíveis no .NET? 
Dê exemplos de uso para cada um deles através de exemplos.*/

/*sbyte 	-128 a 127 	Inteiro de 8 bits com sinal 	
byte 	0 a 255 	Inteiro de 8 bits sem sinal 	
short 	-32.768 a 32.767 	Inteiro de 16 bits com sinal 	
ushort 	0 a 65.535 	Inteiro de 16 bits sem sinal 	
int 	-2.147.483.648 a 2.147.483.647 	Inteiro assinado de 32 bits 	
uint 	0 a 4.294.967.295 	Inteiro de 32 bits sem sinal 	
long 	-9.223.372.036.854.775.808 a 9.223.372.036.854.775.807 	Inteiro assinado de 64 bits 	
ulong 	0 a 18.446.744.073.709.551.615 	Inteiro de 64 bits sem sinal 	
nint 	Depende da plataforma (computada em runtime) 	 	
nuint 	Depende da plataforma (computada em runtime) 	*/

sbyte sbyte1 = -128;
byte byte1 = 255;
short short1 = -32768;
ushort ushort1 = 65535;
int int1 = -2147483648;
uint uint1 = 4294967295;
long long1 = -9223372036854775808;
ulong ulong1 = 18446744073709551615;
nint nint1 = -2147483648;
nuint nuint1 = 4294967295;

sbyte1 = (sbyte)(sbyte1 /2) ;
byte1 = (byte)(byte1 /2) ;
short1 = (short)(short1 /2) ;
ushort1 = (ushort)(ushort1 - 1) ;
int1 = int1 /2 ;
uint1 = uint1 /2 ;
long1 = long1 /2 ;
ulong1 = ulong1 /2 ;
nint1 = nint1 /2 ;
nuint1 = nuint1 /2 ;

Console.WriteLine(sbyte1);
Console.WriteLine(byte1);
Console.WriteLine(short1);
Console.WriteLine(ushort1);
Console.WriteLine(int1);
Console.WriteLine(uint1);
Console.WriteLine(long1);
Console.WriteLine(ulong1);
Console.WriteLine(nint1);
Console.WriteLine(nuint1);

/*Problema3: Suponha que você tenha uma variável do tipo double e deseja convertê-la
em um tipo int. Como você faria essa conversão e o que aconteceria se a parte
fracionária da variável double não pudesse ser convertida em um int? Resolva o
problema através de um exemplo em C#.*/

double double1 = 123.456;
int int2 = (int)double1;
Console.WriteLine(int2);

// A parte fracionaria da variável double não pode ser convertida em um int

/*Problema4: Dada a variável int x = 10 e a variável int y = 3, escreva código para calcular
e exibir o resultado da adição, subtração, multiplicação e divisão de x por y.*/

int x = 10;
int y = 3;
int adicao = x + y;
int subtracao = x - y;
int multiplicacao = x * y;
int divisao = x / y;
Console.WriteLine(adicao);
Console.WriteLine(subtracao);
Console.WriteLine(multiplicacao);
Console.WriteLine(divisao);
// Como é uma divisão de inteiros a resposta é o qoucido da divisão, desconsiderando a parte decimal

/*Problema5: Considere as variáveis int a = 5 e int b = 8. Escreva código para determinar
se a é maior que b e exiba o resultado.*/

int a = 5;
int b = 8;
bool resultado = a > b;
Console.WriteLine(resultado);

/*Problema6: Você tem duas strings, string str1 = "Hello" e string str2 = "World". Escreva
código para verificar se as duas strings são iguais e exibir o resultado.*/
string str1 = "Hello";
string str2 = "World";
bool resultado2 = str1 == str2;
Console.WriteLine(resultado2);

/*Problema: Suponha que você tenha duas variáveis booleanas, bool condicao1 = true
e bool condicao2 = false. Escreva código para verificar se ambas as condições são
verdadeiras e exiba o resultado.*/

bool condicao1 = true;
bool condicao2 = false;
bool resultado3 = condicao1 && condicao2;
Console.WriteLine(resultado3);

/*Problema: Dadas as variáveis int num1 = 7, int num2 = 3, e int num3 = 10, escreva
código para verificar se num1 é maior do que num2 e se num3 é igual a num1 + num2.*/

int num1 = 7;
int num2 = 3;
int num3 = 10;
bool resultado4 = num1 > num2 && num3 == num1 + num2;
Console.WriteLine(resultado4);