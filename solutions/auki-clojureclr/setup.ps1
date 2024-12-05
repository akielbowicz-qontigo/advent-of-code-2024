### Add all setup needed for your project

scoop bucket add versions
scoop install versions/dotnet-sdk-lts
dotnet tool install clojure.main --version 1.12.0-alpha10 --global --add-source https://api.nuget.org/v3/index.json 
dotnet tool install clojure.cljr --version 0.1.0-alpha5 --global --add-source https://api.nuget.org/v3/index.json 
code --install-extension betterthantomorrow.calva
