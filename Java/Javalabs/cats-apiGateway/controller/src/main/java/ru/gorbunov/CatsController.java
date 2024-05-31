package ru.gorbunov;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;
import ru.gorbunov.dto.Breeds;
import ru.gorbunov.dto.CatDto;
import ru.gorbunov.dto.CatReturnDto;
import ru.gorbunov.dto.Colors;

import java.util.List;

@RestController
@RequestMapping("/api/v1/cats")
public class CatsController {
    private final CatsService service;

    @Autowired
    public CatsController(CatsService service) {
        this.service = service;
    }

    @PostMapping
    @PreAuthorize("hasAuthority('ADMIN')")
    public void addCat(@RequestBody CatDto catDto) {
        service.addCat(catDto);
    }

    @DeleteMapping("/{id}")
    @PreAuthorize("hasAuthority('ADMIN')")
    public void deleteCat(@PathVariable("id") long id) {
        service.deleteCat(id);
    }

    @PostMapping("/cat/{catId}/owner/{ownerId}")
    @PreAuthorize("hasAuthority('ADMIN')")
    public void setCatOwner(@PathVariable("catId") long catId, @PathVariable("ownerId") long ownerId) {
        service.setCatOwner(catId, ownerId);
    }

    @PostMapping("/cat/{id}/catFriend/{friendId}")
    @PreAuthorize("hasAuthority('USER')")
    public void addCatFriend(@PathVariable("id") long id, @PathVariable("friendId") long friendId) {
        service.addCatFriend(id, friendId);
    }

    @GetMapping
    @PreAuthorize("hasAuthority('USER')")
    public List<CatReturnDto> findByParams(@RequestParam(value = "color", required = false) Colors color, @RequestParam(value = "breed", required = false) Breeds breed) {
        return service.findByParams(color, breed);
    }
}