#!/usr/bin/env bash

for file in ../*.json
do
  newman run "$file"
done
