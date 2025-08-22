#!/bin/bash

# Bash script to rename NetBoilerplate to a new application name

# Check if the new name is provided
if [ -z "$1" ]; then
    echo "Usage: $0 <NewName>"
    exit 1
fi

# Define the old and new names
OLD_NAME="NetBoilerplate"
NEW_NAME=$1

# Define the root path
ROOT_PATH="src"

# Function to rename folders and files
rename_folders_and_files() {
    local path=$1
    local old_name=$2
    local new_name=$3

    # Rename folders
    find "$path" -type d -name "*$old_name*" | while read -r dir; do
        new_dir=$(echo "$dir" | sed "s/$old_name/$new_name/g")
        mv "$dir" "$new_dir"
    done

    # Rename files
    find "$path" -type f -name "*$old_name*" | while read -r file; do
        new_file=$(echo "$file" | sed "s/$old_name/$new_name/g")
        mv "$file" "$new_file"
    done
}

# Function to replace text in files
replace_text_in_files() {
    local path=$1
    local old_text=$2
    local new_text=$3

    find "$path" -type f | while read -r file; do
        if grep -q "$old_text" "$file"; then
            sed -i "s/$old_text/$new_text/g" "$file"
        fi
    done
}

# Rename folders and files
rename_folders_and_files "$ROOT_PATH" "$OLD_NAME" "$NEW_NAME"

# Replace text in files
replace_text_in_files "$ROOT_PATH" "$OLD_NAME" "$NEW_NAME"

echo "Renaming complete. NetBoilerplate has been renamed to $NEW_NAME."
