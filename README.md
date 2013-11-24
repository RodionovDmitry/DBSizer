DBSizer
=======

This is a tool for fast visualization of databases size on a particular SQL Server.
For selected database it is possible to quickly find tables used most space and / or tables with largest amount of rows.

Tested on SQL Server 2005 and SQL Server 2008. Might work on 2008 R2 and 2012 as well.
It uses SELECT queries to system tables to determine list of databases, their size, list of tables their size etc.

This software requires .NET Framework 4.0 to run.

There are two versions of UI in solution
1) WinForms application with only common WinForms controls.
2) WPF application with some third party contols for charting

Usage of Model-View-Presenter and MVVM patterns is an overkill for this project, but I hope to use it as a demo for my future employers.

