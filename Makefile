ignore := 'test*|obj|bin|Release|Debug'
basePath := ~/projects/personal/interviews/neon
bin := ./bin/Release/net7.0/ChargeAccountManager

# Usage samples:
# 
#   make build 
#   make publish
#   make test
#   make run 

build:
		@dotnet build ChargeAccountManager.csproj --configuration Release
		@tree . -I $(ignore)

publish:
		@dotnet publish ChargeAccountManager.csproj --configuration Release
		@tree . -I $(ignore)

run:
		@$(bin)

clean:
		@cd $(basePath)/charge-account-manager/ && rm -rf ./bin ./obj
		@tree . -I $(ignore)

all: clean build publish
