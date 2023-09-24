VS -> Color Tabs by project selected. Wow

Ctrl + Alt + L - Show Solution Explorer

Rider 

Shift + Shift


### Issue with ports

Message "Failed to bind to address http://localhost:5172."  string
After Windows 10 Update KB4074588, some ports are reserved by Windows and applications cannot bind to these ports. 50067 is in the blocked range.
```
netsh interface ipv4 show excludedportrange protocol=tcp
```

```
netsh interface ipv4 show excludedportrange protocol=tcp
Protocol tcp Port Exclusion Ranges

Start Port    End Port
----------    --------
      5169        5169
      5170        5170
      5172        5172
      5173        5173
      ...
```
So change the ports in Vs Accordingly
