SELECT COUNT(*) 'Open Connections' FROM sysprocesses
WHERE program_name = 'PW2022-UnmanagedResources'