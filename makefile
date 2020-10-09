output: pgm.o
	g++ pgm.o -o output
pgm.o:pgm.cpp
	g++ -c pgm.cpp
clean:
	rm *.o output
