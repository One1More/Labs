package ru.gorbunov.presentation;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.Scanner;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

@Component
@Scope("prototype")
public class ScriptRunner {
    private final List<ScriptProvider> _scricptProviders;

    @Autowired
    public ScriptRunner(List<ScriptProvider> scriptProviders) {

        _scricptProviders = scriptProviders;
    }

    public void run()
    {
        List<Script> scripts = GetScripts();

        System.out.println("Select action:");

        for (int i = 0; i < scripts.size(); i++) {
            System.out.println((i + 1) + ". " + scripts.get(i).Name());
        }

        var scanner = new Scanner(System.in);
        int choice = scanner.nextInt();

        if (choice > 0 && choice <= scripts.size()) {
            var selectedScript = scripts.get(choice - 1);
            selectedScript.run();
        } else {
            System.out.println("Invalid choice");
        }

    }
    
    private List<Script> GetScripts() {

        var result = new ArrayList<Script>();

        for (ScriptProvider scriptProvider : _scricptProviders) {
            Optional<Script> scriptOptional = scriptProvider.tryGetScenario();

            scriptOptional.ifPresent(result::add);
        }

        return result;
    }
}
