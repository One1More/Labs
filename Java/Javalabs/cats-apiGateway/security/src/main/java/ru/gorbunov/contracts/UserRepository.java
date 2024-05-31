package ru.gorbunov.contracts;

import org.springframework.data.jpa.repository.JpaRepository;
import ru.gorbunov.models.User;

import java.util.Optional;

public interface UserRepository extends JpaRepository<User, Integer> {
    Optional<User> findByLogin(String login);
}
