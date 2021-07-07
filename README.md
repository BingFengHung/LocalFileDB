# LocalFileDB
C# .netframework 4 use file as Database

## Concepts
This project mainly use local files as a database

The core concept as follow：
- Folder Name as "Schema" name
- File Name as "Table" name
- File Content use "[Column]" as Column Name and below this string has the Column value.
### FileDatabase
This is the core method to handle the vaule setting to the relative table and column.

### IDatabaseFetch
The IDatabaseFetch is generic class and the T denotes Table and C denotes column.
The user can define enum type to denote table name and column name with relate to the T and C.

Use enum type can avoid string typing wrong to prevent unexpected result.
