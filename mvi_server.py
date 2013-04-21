#!/usr/bin/python
# -*- coding: utf-8 -*-
#-------------------------------------------------
import serial

#ser = serial.Serial("/dev/ttyACM0", 9600, timeout=0)
import pdb
import time

import socket

TCP_IP = '127.0.0.1'
TCP_PORT = 5005
BUFFER_SIZE = 20  # Normally 1024, but we want fast response

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((TCP_IP, TCP_PORT))
s.listen(1)

conn, addr = s.accept()
print 'Connection address:', addr
while 1:
    data = conn.recv(BUFFER_SIZE)
    if not data: break
    print "received data:", data
    conn.send(data)  # echo
            #ser.write()
conn.close()
