#include <iostream>
#include <list>

using namespace std;

template<class T>
void print(const char* Name, list<T>& L) {
	cout << Name << " : ";
	auto it = L.begin();
	while (it!=L.end()){
		cout << *it++ << " ";
	}
	cout << endl;
	cout << "size() = " << L.size() << endl;
}

int main() {
	int arr[] = { 5,7,8,6,5,3,6,8,9,0,1,1 };
	list<int> L(arr,arr+12);
	print("listL", L);
	L.push_front(100);
	L.push_front(102);
	L.push_back(101);
	cout << "push : ";
	print("listL", L);
	L.pop_front();
	L.pop_back();
	cout << "pop : ";
	print("listL", L);
	L.erase(++L.begin());		//list的源码未对 (iterator + number)进行重载
	cout << "erase : ";
	print("listL", L);
	L.remove(5);
	cout << "remove : ";
	print("listL", L);
	L.unique();
	cout << " unique : ";
	print("listL", L);
	
	int ar[] = { 111,119,113,114 };
	list<int> L2(ar, ar + 4);
	L.splice(++L.begin(), L2, L2.begin(), L2.end());
	cout << "splice : ";
	print("listL", L);
	int ar[] = { 211,219,213,214 };
	list<int> L3(ar, ar + 4);
	L.sort();
	L3.sort();
	L.merge(L3,less<int>());
	cout << "merge(L3,less<int>()) : ";
	print("listL", L);
	L.sort(greater<int>());
	cout << "sort(greater<int>()) : ";
	print("listL", L);
	cout << "sucess!" << endl;
}
