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
    implementation("org.springframework.boot:spring-boot-starter-data-jpa:3.2.4")
    implementation("org.springframework.boot:spring-boot-starter-web:3.2.4")
    implementation(project(":cats-CatsMicroservice:client"))
    implementation(project(":cats-OwnersMicroservice:ownersClient"))
    implementation(project(":cats-CatsMicroservice:model"))
    implementation(project(":cats-OwnersMicroservice:ownersModel"))
    implementation(project(":cats-apiGateway:kafka"))
    implementation(project(":cats-apiGateway:kafkaMessages"))
}

tasks.test {
    useJUnitPlatform()
}