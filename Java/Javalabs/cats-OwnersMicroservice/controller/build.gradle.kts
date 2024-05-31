plugins {
    id("java")
}

group = "ru.gorbunov"
version = "1.0-SNAPSHOT"

repositories {
    mavenCentral()
}

dependencies {
    testImplementation(platform("org.junit:junit-bom:5.10.0"))
    testImplementation("org.junit.jupiter:junit-jupiter")
    implementation("org.springframework:spring-context:6.1.3")
    implementation("org.springframework.boot:spring-boot-starter-web:3.2.4")
    compileOnly("org.projectlombok:lombok:1.18.32")
    annotationProcessor("org.projectlombok:lombok:1.18.32")
    implementation(project(":cats-OwnersMicroservice:ownersModel"))
    implementation(project(":cats-OwnersMicroservice:service"))
}

tasks.test {
    useJUnitPlatform()
}