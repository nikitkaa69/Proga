#include <iostream>
#include "Lab10.h"
// ������, 2 ���� ��� ������-������� ������
// ��� ������-������ ������ ����� ��������� ����, ��������� ��������� ����� ����� � �� ������� �������� - ������ ������ ���������, ��� �� 1 ���.
int main()
{
	
	setlocale(LC_ALL, "rus");
	Tree tree;
	/*
	//tree.multiInput();
	
	tree.add(8);
	tree.add(3);
	tree.add(1);
	tree.add(6);
	tree.add(4);
	tree.add(7);
	tree.add(10);
	tree.add(14);
	tree.add(13);
	tree.add(15);
	tree.add(16);
	tree.add(17);




	tree.dfprint();
	printf("treesize:%d\n",tree.getSize());
	//printf("DFS\nleft:%d\nright:%d\n", tree.dfs(3)->left->num,tree.dfs(3)->right->num);
	tree.sort();
	
	//printf("���������� �������� ��������� �����:%d\n", tree.osn1());
	//printf("���������� �������� ��������� ������:%d\n", tree.dop2());
	//printf("����� �������� ���� ���������:%d\n", tree.dop16());
	//��� 14
	//printf("������� �������������� ���� ��������� ������:%d\n", tree.dop16() / tree.getSize());

	//node *parent;
	//node *toDel = tree.dfs(8, parent);
	//tree.del(toDel, parent);

	//tree.dfprint();
	//tree.sort();

	
	std::cout << " =========================================\n";
	std::cout << " ||\t\t��� 11\t\t\t||\n";
	std::cout << " =========================================\n";
	
	
	bool b;
	b = tree.balanced();
	char* res;
	if (b) res = "true";
	else res = "false";

	std::cout << "������������������ ������: " << res;
	*/

	Tree unstree;
	unstree.adduns(1);
	unstree.adduns(2);
	unstree.adduns(3);
	unstree.adduns(4);
	unstree.adduns(5);
	unstree.sort();
	printf("\n\n");

	// ================================

	Tree mobtree;

	mobtree.addMob(1, "A1");
	mobtree.addMob(2, "A1");
	mobtree.addMob(3, "MTS");
	mobtree.addMob(4, "MTS");
	mobtree.addMob(5, "MTS");
	mobtree.addMob(6, "Life:)");
	mobtree.addMob(7, "MTS");

	printf("recommended: %s\n", mobtree.findMax());

	mobtree.dfprint();
	getchar();
}



bool check(char str[])
{

	for (int i = 0; i < strlen(str); i++)
	{
		if (!(str[i] >= '0' && str[i] <= '9') && (str[i] != '-') && (str[i] != '.') && (str[i] != ','))
			return false;
	}

	return true;
}