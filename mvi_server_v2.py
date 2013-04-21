# Echo server program
import socket
import sys
import serial

HOST = None               # Symbolic name meaning all available interfaces
PORT = 8011              # Arbitrary non-privileged port

import termios, fcntl, sys, os
fd = sys.stdin.fileno()

ser = serial.Serial("/dev/ttyACM1", 9600, timeout=0)
s = None
for res in socket.getaddrinfo(HOST, PORT, socket.AF_UNSPEC,
                              socket.SOCK_STREAM, 0, socket.AI_PASSIVE):
    af, socktype, proto, canonname, sa = res
    try:
        s = socket.socket(af, socktype, proto)
        s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    except socket.error as msg:
        s = None
        continue
    try:
        s.bind(sa)
        s.listen(1)
    except socket.error as msg:
        s.close()
        s = None
        continue
    break
if s is None:
    print 'could not open socket'
    sys.exit(1)
conn, addr = s.accept()
print 'Connected by', addr
while 1:
    data = conn.recv(1024)
    print data

    try:
        if(data.find("w") != -1):
            ser.write("x0,y2%")
        if(data.find("a") != -1):
            ser.write("x-2,y0%")
        if(data.find("s") != -1):
            ser.write("x0,y0%")
        if(data.find("d") != -1):
            ser.write("x2,y0%")
        if(data.find("x") != -1):
            ser.write("x0,y-2%")
        if(data.find("close") != -1):
            print "shutting down"
            conn.shutdown(socket.SHUT_RDWR)
            conn.close()
            print "connection closed"
            sys.exit()
            print "should have exited by now"
    except Exception:
        continue
     
    ser.write(data)
    if not data: break
    conn.send(data)
conn.close()
