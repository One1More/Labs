package ru.gorbunov;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class CatAndOwnerDto {
    private final long catId;
    private final long ownerId;
}
