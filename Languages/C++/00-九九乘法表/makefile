all: Table.out

Table.out: Table.o
	g++ Table.o -o Table.out

Table.o: Table.cpp
	g++ -c Table.cpp -o Table.o

clean:
	rm -rf *.o Table
