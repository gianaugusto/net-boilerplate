# PowerShell script to rename NetBoilerplate to a new application name
param (
    [Parameter(Mandatory = $true)]
    [string]$NewName
)

# Function to rename folders and files
function Rename-FoldersAndFiles {
    param (
        [string]$Path,
        [string]$OldName,
        [string]$NewName
    )

    # Rename folders
    Get-ChildItem -Path $Path -Directory -Recurse -Filter "*$OldName*" | ForEach-Object {
        $newFolderName = $_.Name -replace "$OldName", $NewName
        Rename-Item -Path $_.FullName -NewName $newFolderName
    }

    # Rename files
    Get-ChildItem -Path $Path -File -Recurse -Filter "*$OldName*" | ForEach-Object {
        $newFileName = $_.Name -replace "$OldName", $NewName
        Rename-Item -Path $_.FullName -NewName $newFileName
    }
}

# Function to replace text in files
function Replace-TextInFiles {
    param (
        [string]$Path,
        [string]$OldText,
        [string]$NewText
    )

    Get-ChildItem -Path $Path -File -Recurse | ForEach-Object {
        $content = Get-Content -Path $_.FullName -Raw
        if ($content -match $OldText) {
            $newContent = $content -replace $OldText, $NewText
            Set-Content -Path $_.FullName -Value $newContent
        }
    }
}

# Define the old and new names
$OldName = "NetBoilerplate"
$NewName = $NewName

# Define the root path
$RootPath = "src"

# Rename folders and files
Rename-FoldersAndFiles -Path $RootPath -OldName $OldName -NewName $NewName

# Replace text in files
Replace-TextInFiles -Path $RootPath -OldText $OldName -NewText $NewName

Write-Output "Renaming complete. NetBoilerplate has been renamed to $NewName."
