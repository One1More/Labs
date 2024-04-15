package ru.gorbunov.presentation;

import java.util.Optional;

public interface ScriptProvider {
    Optional<Script> tryGetScenario();
}
